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
using CollectionManagement.Services;
using SQLitePCL;
using System.Security.Claims;

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

            var collectionsById = _collectionsService.GetCollectionsByUserId(userId);
            return View(collectionsById);
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
        public IActionResult Create(MyCollection collection)
        {
            if (ModelState.IsValid)
            {
                collection.AppUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                _collectionsService.Insert(collection);
                return RedirectToAction("Index", "Collections");
            }
            return View(collection);
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
            return View(collection);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, MyCollection collection)
        {
            if (id != collection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _collectionsService.Update(collection);
                return RedirectToAction(nameof(Index));
            }
            return View(collection);
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
