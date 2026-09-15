using LibSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace LibSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly LibraryDbContext _context;

        public AccountController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var student = _context.Students.FirstOrDefault(s =>
                s.Email == email && s.Password == password);

            if (student == null)
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }

            // Session
            HttpContext.Session.SetInt32("StudentId", student.Id);

            // Cookie
            Response.Cookies.Append("StudentEmail", student.Email);

            // Claims
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, student.Email),
        new Claim(ClaimTypes.Role, student.Role)
    };

            var identity = new ClaimsIdentity(
                claims,
                "CookieAuth"
            );

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                "CookieAuth",
                principal
            );

            return RedirectToAction("Index", "Book");
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();

            Response.Cookies.Delete("StudentEmail");

            await HttpContext.SignOutAsync("CookieAuth");

            return RedirectToAction("Index", "Home");
        }
    }
}
