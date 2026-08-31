using AutoMapper;
using FinalApi.Data;
using FinalApi.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(InventoryDbContext _context,IMapper _mapper) : ControllerBase
    {
        [HttpGet]

        public IActionResult Get()
        {
            var products = _context.Products.Include(e => e.Category).ToList();

            var dtos= _mapper.Map<List<ProductDTO>>(products);
            return Ok(dtos);

            //var dtos = new List<ProductDTO>();
            //foreach (var item in product)
            //{
            //    var dto = new ProductDTO()
            //    {
            //        Id = item.Id,
            //        Title = item.Title,
            //        Qty = item.Quantity,
            //        CategoryID = item.CategoryId,
            //        CategoryName = item.Category.Title

            //    };
            //    dtos.Add(dto);
            //}

        }
    }
}
