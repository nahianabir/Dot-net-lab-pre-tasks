using lab4.Data;
using lab4.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace lab4.Controllers
{
    public class FacultyController(UmsDbContext _context) : Controller
    {
        public IActionResult Index()
        {
            // have to execute manuallay
            //IQueryable<Faculty> data = _context.Faculties;


            //data executes and comes to memory
            List<Faculty> data = _context.Faculties.ToList();
            return View(data);
        }

        public IActionResult Delete(int fid) 
        {
            var data= _context.Faculties.FirstOrDefault(e=>e.Id==fid);
            if (data != null)
            {
                _context.Faculties.Remove(data);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
