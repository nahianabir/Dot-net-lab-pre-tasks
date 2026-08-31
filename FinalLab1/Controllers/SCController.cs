using Microsoft.AspNetCore.Mvc;

namespace FinalLab1.Controllers
{
    public class SCController : Controller
    {
        public IActionResult SetData()

        {
            //presistent cookie
            var option = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(5),
                HttpOnly = true,
                IsEssential = true
            };

            HttpContext.Response.Cookies.Append("Email", "jh99@gmail.com", option);//add option parameter to use presistent cookie
            HttpContext.Session.SetString("Username", "jh99");
            return Content("set data");
        }

        public IActionResult GetData()
        {
            var email = HttpContext.Request.Cookies["Email"] ?? "empty";
            var un= HttpContext.Session.GetString("Username")?? "empty";
            return Content($"Cookie:{email}");
        }


        public IActionResult RemoveData()
        {
            HttpContext.Response.Cookies.Delete("Email");
            HttpContext.Session.Remove("Username");
            return Content("remove data");
        }
    }
}
