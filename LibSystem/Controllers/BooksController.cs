using LibSystem.Data;
using LibSystem.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly LibraryDbContext _context;

        public BooksController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = _context.Books
                .Include(b => b.Category)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Category = b.Category.Name,
                    AvailableCopies = b.AvailableCopies
                })
                .ToList();

            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var book = _context.Books
                .Include(b => b.Category)
                .Where(b => b.Id == id)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Category = b.Category.Name,
                    AvailableCopies = b.AvailableCopies
                })
                .FirstOrDefault();

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}
