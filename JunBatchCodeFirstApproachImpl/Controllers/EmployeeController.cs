using JunBatchCodeFirstApproachImpl.Data;
using JunBatchCodeFirstApproachImpl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JunBatchCodeFirstApproachImpl.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext db;


        public EmployeeController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            ViewBag.managers = new SelectList(db.Manager.ToList(), "Mid", "Mname");
            return View();
        }

        [HttpPost]
        public IActionResult Index(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return Json("");
        }

        public IActionResult fetchemp()
        {
            var data = db.Employees.ToList();
            return Json(data);
        }
        public IActionResult delemp(int empid)
        {
            var data = db.Employees.Find(empid);
            db.Employees.Remove(data);
            db.SaveChanges();
            return Json(data);
        }

        public IActionResult getemp()
        {
            var data = db.Employees.Include(x => x.manager).Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                email = e.email,
                Role = e.Role,
                salary = e.salary,
                Mid = e.Mid,
                Mname = e.manager.Mname
            });
            return Json(data);
        }

        public IActionResult editemp(int empid)
        {
            var data = db.Employees.Find(empid);
            return Json(data);
        }
        public IActionResult updateEmp(UEmployeeDto e)
        {
            var emp = new Employee
            {
                Id = e.Id,
                Name = e.Name,
                email = e.email,
                Role = e.Role,
                salary = e.salary,
                Mid = e.Mid
            };
            db.Employees.Update(emp);
            db.SaveChanges();
            return Json("");
        }
       
    }
}
