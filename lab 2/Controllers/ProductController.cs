using Microsoft.AspNetCore.Mvc;

namespace lab_2.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult List(string category, int id)
        {
            ViewBag.Category = category;
            ViewBag.Id = id;
            return View();
        }
    }
}
