using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BookLibraryExam.Models;

namespace BookLibraryExam.Controllers
{
    public class BooksController : Controller
    {
        private static List<Book> books = new List<Book>();

        public ActionResult Index()
        {
            return View(books);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = books.Count + 1;
                books.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null) return HttpNotFound();
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var b = books.FirstOrDefault(x => x.Id == book.Id);
                if (b == null) return HttpNotFound();
                b.Title = book.Title;
                b.Author = book.Author;
                b.ISBN = book.ISBN;
                b.PublicationYear = book.PublicationYear;
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var b = books.FirstOrDefault(x => x.Id == id);
            if (b != null) books.Remove(b);
            return RedirectToAction("Index");
        }
    }
}



