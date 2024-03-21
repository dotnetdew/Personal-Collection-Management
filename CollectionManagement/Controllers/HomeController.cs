using CollectionManagement.Models;
using CollectionManagement.Services;
using CollectionManagement.ViewModels.MyCollection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CollectionManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICollectionsService _collectionsService;
        public HomeController(ICollectionsService collectionsService)
        {
            _collectionsService = collectionsService;
        }

        public IActionResult Index()
        {
            var Collections = _collectionsService.GetAll();

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
