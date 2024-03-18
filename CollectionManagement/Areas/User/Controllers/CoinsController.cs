using Microsoft.AspNetCore.Mvc;

namespace CollectionManagement.Areas.User.Controllers
{
    public class CoinsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}