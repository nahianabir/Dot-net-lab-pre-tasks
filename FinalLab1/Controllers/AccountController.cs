using FinalLab1.EF;
using FinalLab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalLab1.Controllers
{
    public class AccountController(SchoolDbContext _context) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginVm model)
        {
            if (ModelState.IsValid==false)
            {
                return View(model);


            }

            var ui=_context.UserInfo.FirstOrDefault(e=>e.Email==model.Email && e.Password==model.Password);
            if (ui == null) {
                ModelState.AddModelError("Email", "Inavild mail or pass");
                return View(model);
            }

            HttpContext.Session.SetString("Email",ui.Email);
            HttpContext.Session.SetString("Role", ui.Role);

            return RedirectToAction("Index","Home");
        }
    }
}
