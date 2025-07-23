using JunBatchCodeFirstApproachImpl.Data;
using JunBatchCodeFirstApproachImpl.Models;
using Microsoft.AspNetCore.Mvc;
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
           var data= db.Employees.ToList();
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

            var data = db.employee.Include(a => a.manager).ToList();
            return Json("data");

        }

        public IActionResult editemp(int empid)
        {
           var data= db.Employees.Find(empid);
            return Json(data);
        }
        public IActionResult updateEmp(Employee e) 
        {
            db.Employees.Update(e);
            db.SaveChanges();
            return Json("");
        }
    }
}
