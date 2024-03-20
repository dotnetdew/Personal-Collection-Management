using CollectionManagement.Models;
using CollectionManagement.Repositories;
using CollectionManagement.Services;
using CollectionManagement.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using System.Security.Claims;

namespace CollectionManagement.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly ICollectionsService collectionsService;
        public BooksController(IBookService _bookService, ICollectionsService _collectionsService)
        {
            bookService = _bookService;
            collectionsService = _collectionsService;
        }
        public ActionResult Index(Guid collectionId)
        {
            var books = bookService.GetBooksByCollectionId(collectionId);

            var bookVMs = books.Select(book => new BookVM()
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Tag = book.Tag,
                PublicationYear = book.PublicationYear,
                CollectionId = book.CollectionId,
                ImageSrc = $"data:{book.ImageMimeType};base64,{Convert.ToBase64String(book.ImageData)}"
            });

            ViewBag.CollectionId = collectionId;

            return View(bookVMs);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: BooksController/Create
        public ActionResult Create(Guid collectionId)
        {
            var collection = collectionsService.GetById(collectionId);

            if (collection is null)
                return BadRequest();

            var bookVM = new BookCreateVM();
            bookVM.CollectionId = collection.Id;

            return View(bookVM);
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreateVM bookVM)
        {
            if (ModelState.IsValid)
            {
                var collection = collectionsService.GetById(bookVM.CollectionId);

                if (collection is null)
                    return BadRequest("Collection Not Found");

                var book = bookVM.MapToModel();

                bookService.Insert(book);
                return RedirectToAction("Index", "Books", new { collectionId = book.CollectionId });
            }
            return View(bookVM);
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookEditVM = new BookEditVM(book);

            return View(bookEditVM);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, BookEditVM bookVM)
        {
            if (id != bookVM.Id)
            {
                return NotFound();
            }

            var existingBook = bookService.GetById(bookVM.Id);
            if (existingBook == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var book = bookVM.MapToModel(existingBook);
                bookService.Update(book);
                return RedirectToAction("Index", new { collectionId = book.CollectionId });
            }
            return View(bookVM);
        }

        // GET: BooksController/Delete/5
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collection = bookService.GetById(id);
            if (collection == null)
            {
                return NotFound();
            }

            return View(collection);
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var book = bookService.GetById(id);
            if (book != null)
            {
                bookService.Delete(book);
            }
            return RedirectToAction("Index", new { collectionId = book.CollectionId });
        }
    }
}
