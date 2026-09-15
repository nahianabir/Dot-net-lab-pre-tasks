using Final1.Data;
using Final1.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Neurology")]
    public class DoctorController(HospitalContext _db) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = _db.Doctors.ToList();

            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {

            var data = _db.Doctors.Find(id);

            if (data == null)
            {

                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpPost]

        public IActionResult Save(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_db.Doctors.Any(e => e.DoctorId == doctor.DoctorId)==false)
            {
                _db.Doctors.Add(doctor);
            }

            else
            {
                _db.Doctors.Update(doctor);
            }

            _db.SaveChanges();

            return Ok(doctor);
        }
        
    }
}
