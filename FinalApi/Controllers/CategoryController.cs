using FinalApi.Data;
using FinalApi.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(InventoryDbContext _context) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var categories = _context.Categories.ToList();

            return Ok(categories);
        }

        [HttpGet("{id:int}")]

        public IActionResult Get(int id) {

            var category = _context.Categories.Find(id);
            return Ok(category);
        }

        [HttpPost]

        public IActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.Categories.Any(e=>e.Id==category.Id)==false)
                _context.Categories.Add(category);
            else
            {
                _context.Categories.Update(category);
            }

            _context.SaveChanges();
            return Ok();
        }

    }
}
