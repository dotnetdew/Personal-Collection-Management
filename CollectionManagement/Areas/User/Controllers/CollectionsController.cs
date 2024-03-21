using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CollectionManagement.Data;
using CollectionManagement.Models;
using Microsoft.AspNetCore.Authorization;
using SQLitePCL;
using System.Security.Claims;
using CollectionManagement.Services;
using CollectionManagement.ViewModels.MyCollection;

namespace CollectionManagement.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class CollectionsController : Controller
    {
        private readonly ICollectionsService _collectionsService;

        public CollectionsController(ICollectionsService collectionsService)
        {
            _collectionsService = collectionsService;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var Collections = _collectionsService.GetCollectionsByUserId(userId);

            var collectionsVM = Collections.Select(c => new MyCollectionVM()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Topic = c.Topic,
                ImageSrc = $"data:{c.ImageMimeType};base64,{Convert.ToBase64String(c.ImageData)}"
            });

            return View(collectionsVM);
        }

        public IActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collection = _collectionsService.GetById(id);
            if (collection == null)
            {
                return NotFound();
            }

            return View(collection);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MyCollectionCreateVM collectionVM)
        {
            if (ModelState.IsValid)
            {
                collectionVM.AppUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var collection = collectionVM.MapToModel();

                _collectionsService.Insert(collection);
                return RedirectToAction("Index", "Collections");
            }
            return View(collectionVM);
        }

        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collection = _collectionsService.GetById(id);
            if (collection == null)
            {
                return NotFound();
            }

            var collectionEditVM = new MyCollectionEditVM(collection);

            return View(collectionEditVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, MyCollectionEditVM collectionVM)
        {
            if (id != collectionVM.Id)
            {
                return NotFound();
            }

            var existingCollection = _collectionsService.GetById(id);
            if (existingCollection == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var Collection = collectionVM.MapToModel(existingCollection);

                _collectionsService.Update(Collection);
                return RedirectToAction(nameof(Index));
            }
            return View(collectionVM);
        }

        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collection = _collectionsService.GetById(id);
            if (collection == null)
            {
                return NotFound();
            }

            return View(collection);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var collection = _collectionsService.GetById(id);
            if (collection != null)
            {
                _collectionsService.Delete(collection);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}