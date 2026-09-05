using Company.EF.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Company.EF;
using AutoMapper;
using Company.DTOS;

namespace Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CompanyApiDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(CompanyApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //get: api/employee

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _context.Employees.Include(e => e.Department).ToList();
            var dtos = _mapper.Map<List<EmployeeDTO>>(employees);
            return Ok(dtos);
        }



        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {


            var employee = _context.Employees.Include(e => e.Department).FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null) return NotFound(new { message = "Employee not found." });
            return Ok(_mapper.Map<EmployeeDTO>(employee));
        }

        [HttpPost("Save")]

        public IActionResult Save([FromBody] EmployeeSaveDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var emp = _mapper.Map<Employee>(dto);

            //emp.UpdatedAt = DateTime.UtcNow;

            if (!_context.Employees.Any(e => e.EmployeeId == emp.EmployeeId))
            {
                _context.Employees.Add(emp);
            }

            else
            {
                _context.Employees.Update(emp);
            }

            _context.SaveChanges();
            return Ok(new { message = "emp saved", data=emp });
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null) return NotFound(new { message = "emp not found" });

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return Ok (new {message="emp deleted"});
        }

    }
}
