using System.Collections.Immutable;
using AutoMapper;
using Final1.Data;
using Final1.Data.Entities;
using Final1.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController (HospitalContext _db, IMapper _map): ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = _db.Patients.Include(e => e.Doctor).ToList();

            var dtos = _map.Map<List<PatitentDTO>>(data);
           /* var dtos = new List<PatitentDTO>();
            foreach (var item in data)
            {
                var dto = new PatitentDTO()
                {
                    PatientId = item.PatientId,
                    Name=item.Name,
                    Age=(int)item.Age,
                    DoctorId = (int)item.DoctorId,
                    DoctorName = item.Doctor.Name
                };
                dtos.Add(dto);
            }*/

            return Ok(dtos);
        }

        [HttpPost]
        public IActionResult Save(PatientSaveDTO p)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            var patient = _map.Map<Patient>(p);

           
            if (_db.Patients.Any(e => e.PatientId == p.PatientId) == false)
            {
                _db.Patients.Add(patient);
            }
            else
            {

                _db.Patients.Update(patient);
            }

            _db.SaveChanges();

            var model = _map.Map<PatientSaveDTO>(patient);
            return Ok(model);

        }
    }
}
