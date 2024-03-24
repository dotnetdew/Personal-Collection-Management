using CollectionManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CollectionManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ManageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpPost]
        public IActionResult Block(Guid appUserId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete([FromForm(Name = "userIds[]")]string[] IDs)
        {
            foreach (var user in _userManager.Users)
            {
                if (IDs.Contains(user.Id))
                {
                    _userManager.DeleteAsync(user);
                }
            }

            return RedirectToAction("Index");
        }
    }
}