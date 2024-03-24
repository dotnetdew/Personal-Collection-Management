using CollectionManagement.Services;
using CollectionManagement.ViewModels.PostStamp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionManagement.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class PostStampsController : Controller
    {
        private readonly IPostStampService postStampService;
        private readonly ICollectionsService collectionsService;

        public PostStampsController(IPostStampService _postStampService, ICollectionsService _collectionsService)
        {
            postStampService = _postStampService;
            collectionsService = _collectionsService;
        }

        public IActionResult Index(Guid collectionId)
        {
            var PostStamps = postStampService.GetCoinsByCollectionId(collectionId);

            var postStampVMs = PostStamps.Select(p => new PostStampVM()
            {
                Id = p.Id,
                Country = p.Country,
                Description = p.Description,
                Name = p.Name,
                ImageSrc = $"data:{p.ImageMimeType};base64,{Convert.ToBase64String(p.ImageData)}"
            });

            ViewBag.CollectionId = collectionId;

            return View(postStampVMs);
        }

        public ActionResult Create(Guid collectionId)
        {
            var collection = collectionsService.GetById(collectionId);

            if (collection is null)
                return BadRequest();

            var postStampVM = new PostStampCreateVM();
            postStampVM.CollectionId = collectionId;

            return View(postStampVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostStampCreateVM postStampVM)
        {
            if (ModelState.IsValid)
            {
                var collection = collectionsService.GetById(postStampVM.CollectionId);

                if (collection is null)
                    return BadRequest("Collection Not Found");

                var postStamp = postStampVM.MapToModel();

                postStampService.Insert(postStamp);
                return RedirectToAction("Index", "PostStamps", new { collectionId = postStamp.CollectionId });
            }
            return View(postStampVM);
        }

        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postStamp = postStampService.GetById(id);
            if (postStamp == null)
            {
                return NotFound();
            }

            return View(postStamp);
        }

        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postStamp = postStampService.GetById(id);
            if (postStamp == null)
            {
                return NotFound();
            }

            var postStampEditVM = new PostStampEditVM(postStamp);

            return View(postStampEditVM);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, PostStampEditVM postStampVM)
        {
            if (id != postStampVM.Id)
            {
                return NotFound();
            }

            var existingCoin = postStampService.GetById(postStampVM.Id);
            if (existingCoin == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var coin = postStampVM.MapToModel(existingCoin);
                postStampService.Update(coin);
                return RedirectToAction("Index", new { collectionId = coin.CollectionId });
            }
            return View(postStampVM);
        }

        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postStamp = postStampService.GetById(id);
            if (postStamp == null)
            {
                return NotFound();
            }

            return View(postStamp);
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var postStamp = postStampService.GetById(id);
            if (postStamp != null)
            {
                postStampService.Delete(postStamp);
            }
            return RedirectToAction("Index", new { collectionId = postStamp.CollectionId });
        }
    }
}