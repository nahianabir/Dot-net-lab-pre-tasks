using LibSystem.Data;
using LibSystem.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibSystem.Controllers
{
    public class BorrowController : Controller
    {
        private readonly LibraryDbContext _context;

        public BorrowController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create(int bookId)
        {
            var studentId =
                HttpContext.Session.GetInt32("StudentId");

            if (studentId == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account"
                );
            }

            var book = _context.Books
                .FirstOrDefault(b => b.Id == bookId);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult CreatePost(int bookId)
        {
            var studentId =
                HttpContext.Session.GetInt32("StudentId");

            if (studentId == null)
            {
                return RedirectToAction(
                    "Login",
                    "Account"
                );
            }

            var book = _context.Books
                .FirstOrDefault(b => b.Id == bookId);

            if (book == null)
            {
                return NotFound();
            }

            if (book.AvailableCopies <= 0)
            {
                return BadRequest(
                    "No copies available."
                );
            }

            var borrow = new Borrow
            {
                StudentId = studentId.Value,
                BookId = bookId,
                BorrowDate = DateTime.Now
            };

            book.AvailableCopies--;

            _context.Borrows.Add(borrow);

            _context.SaveChanges();

            return RedirectToAction(
                "Index",
                "Book"
            );
        }
    }
}
