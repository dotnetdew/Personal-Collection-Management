using CollectionManagement.Data;
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
        private readonly ApplicationDbContext _context;
        public ManageController(UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpPost]
        public IActionResult Block([FromForm(Name = "userIds[]")] string[] IDs)
        {
            var users = _context.Users.ToList();

            foreach (var user in users)
            {
                if (IDs.Contains(user.Id))
                {
                    user.IsBlocked = true;
                    _context.Update(user);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UnBlock([FromForm(Name = "userIds[]")] string[] IDs)
        {
            var users = _context.Users.ToList();

            foreach (var user in users)
            {
                if (IDs.Contains(user.Id))
                {
                    user.IsBlocked = false;
                    _context.Update(user);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete([FromForm(Name = "userIds[]")]string[] IDs)
        {
            var users = _context.Users.ToList();

            foreach (var user in users)
            {
                if (IDs.Contains(user.Id))
                {
                    _context.Remove(user);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}