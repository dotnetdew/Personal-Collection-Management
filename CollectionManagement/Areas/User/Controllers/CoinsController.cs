using CollectionManagement.Services;
using CollectionManagement.ViewModels.Coin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollectionManagement.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class CoinsController : Controller
    {
        private readonly ICoinService coinService;
        private readonly ICollectionsService collectionsService;

        public CoinsController(ICoinService _coinService, ICollectionsService _collectionsService)
        {
            coinService = _coinService;
            collectionsService = _collectionsService;
        }

        public ActionResult Index(Guid collectionId)
        {
            var books = coinService.GetCoinsByCollectionId(collectionId);

            var coinVMs = books.Select(coin => new CoinVM()
            {
                Id = coin.Id,
                Name = coin.Name,
                Country = coin.Country,
                Description = coin.Description,
                ValueInUSD = coin.ValueInUSD,
                CollectionId = coin.CollectionId,
                ImageSrc = $"data:{coin.ImageMimeType};base64,{Convert.ToBase64String(coin.ImageData)}"
            });

            ViewBag.CollectionId = collectionId;

            return View(coinVMs);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coin = coinService.GetById(id);
            if (coin == null)
            {
                return NotFound();
            }

            return View(coin);
        }

        // GET: BooksController/Create
        public ActionResult Create(Guid collectionId)
        {
            var collection = collectionsService.GetById(collectionId);

            if (collection is null)
                return BadRequest();

            var coinVM = new CoinCreateVM();
            coinVM.CollectionId = collection.Id;

            return View(coinVM);
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CoinCreateVM coinVM)
        {
            if (ModelState.IsValid)
            {
                var collection = collectionsService.GetById(coinVM.CollectionId);

                if (collection is null)
                    return BadRequest("Collection Not Found");

                var coin = coinVM.MapToModel();

                coinService.Insert(coin);
                return RedirectToAction("Index", "Coins", new { collectionId = coin.CollectionId });
            }
            return View(coinVM);
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coin = coinService.GetById(id);
            if (coin == null)
            {
                return NotFound();
            }

            var coinEditVM = new CoinEditVM(coin);

            return View(coinEditVM);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, CoinEditVM coinVM)
        {
            if (id != coinVM.Id)
            {
                return NotFound();
            }

            var existingCoin = coinService.GetById(coinVM.Id);
            if (existingCoin == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var coin = coinVM.MapToModel(existingCoin);
                coinService.Update(coin);
                return RedirectToAction("Index", new { collectionId = coin.CollectionId });
            }
            return View(coinVM);
        }

        // GET: BooksController/Delete/5
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coin = coinService.GetById(id);
            if (coin == null)
            {
                return NotFound();
            }

            return View(coin);
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var coin = coinService.GetById(id);
            if (coin != null)
            {
                coinService.Delete(coin);
            }
            return RedirectToAction("Index", new { collectionId = coin.CollectionId });
        }
    }
}