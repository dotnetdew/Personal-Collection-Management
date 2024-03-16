using CollectionManagement.Models;
using CollectionManagement.Repositories;
using CollectionManagement.Services;
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

            return View(books);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(Guid id)
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

        // GET: BooksController/Create
        public ActionResult Create(Guid collectionId)
        {
            var collection = collectionsService.GetById(collectionId);

            if (collection is null)
                return BadRequest();

            var book = new Book();
            book.CollectionId = collection.Id;

            return View(book);
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            ModelState.Remove("Collection");

            var collection = collectionsService.GetById(book.CollectionId);

            if (collection is null)
                return NotFound("Colllection Not Found");

            book.Collection = collection;

            if (ModelState.IsValid)
            {
                bookService.Insert(book);
                return RedirectToAction("Index", "Books", new { collectionId = book.CollectionId });
            }
            return View(book);
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(Guid id)
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

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bookService.Update(book);
                return RedirectToAction("Index", new { collectionId = book.CollectionId });
            }
            return View(book);
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
