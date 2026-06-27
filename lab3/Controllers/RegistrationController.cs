using Microsoft.AspNetCore.Mvc;
using lab3.Models;

namespace lab3.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Show the empty registration form
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        // POST: Receive and validate the submitted form
        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            // Validation passed — show success
            ViewBag.Message = "Registration successful for " + student.Name;
            return View("Success", student);
        }



    }
}
