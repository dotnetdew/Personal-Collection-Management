using CollectionManagement.Models;
using CollectionManagement.Services;
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
            return View(_collectionsService.GetAll());
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
