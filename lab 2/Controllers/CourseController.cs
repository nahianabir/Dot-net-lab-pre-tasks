using Microsoft.AspNetCore.Mvc;

namespace lab_2.Controllers
{
    [Route("courses")]
    public class CourseController : Controller
    {
        // Accessible at: /courses
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Title = "All Courses";
            return View();
        }
        // Accessible at: /courses/details/5
        [Route("details/{id:int}")]
        public IActionResult Details(int id)
        {
            ViewBag.CourseId = id;
            return View();
        }

        // Accessible at: /courses/search?keyword=mvc
        [Route("search")]
        public IActionResult Search(string keyword)
        {
            ViewBag.Keyword = keyword;
            return View();
        }


    }
}