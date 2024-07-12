using CoreKitaplik.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreKitaplik.Controllers
{
    public class DefaultController : Controller
    {

        private AppDbContext _context;

        public DefaultController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books.ToList();

            return View(books);
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            return View();
        }
    }
}
