using System.Security.Claims;
using AutoMapper;
using Final1.Data;
using Final1.DTOS;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AccountController(HospitalContext _db, IMapper _map) : ControllerBase
    {
        [HttpPost ("login")]
        public async Task<IActionResult> Login(LoginDTO log)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var ui = _db.Doctors.FirstOrDefault(e => e.DoctorId == log.DoctorId && e.Name == log.Name);

            if (ui == null)
            {
                ModelState.AddModelError("ID","Invalid Id ");
                return NotFound(ModelState);
            }

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name,ui.Name));
            claims.Add(new Claim(ClaimTypes.Role,ui.Specialization));

            var identity = new ClaimsIdentity(claims, "Myapi");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("Myapi", principal);
            return Ok("Login Successful");


        }

        [HttpPost("logout")]

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Myapi");
            return Ok("Logout Successfull");
        }

    }
}
