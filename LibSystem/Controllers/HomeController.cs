using System.Diagnostics;
using LibSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibSystem.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

    }
}
