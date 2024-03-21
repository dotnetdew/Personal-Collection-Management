using CollectionManagement.Services;
using CollectionManagement.ViewModels.PostStamp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace CollectionManagement.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class PostStampsController : Controller
    {
        private readonly IPostStampService postStampService;

        public PostStampsController(IPostStampService _postStampService)
        {
            postStampService = _postStampService;
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
    }
}