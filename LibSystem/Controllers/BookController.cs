using LibSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace LibSystem.Controllers
{
    [Authorize]
    [Route("Books")]
    public class BookController : Controller
    {
        private readonly LibraryDbContext _context;

        public BookController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books
                .Include(b => b.Category)
                .ToList();

            return View(books);
        }

        [Route("books/details/{id:int}")]
        public IActionResult Details(int id)
        {
            var book = _context.Books
                .Include(b => b.Category)
                .FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    }
}
