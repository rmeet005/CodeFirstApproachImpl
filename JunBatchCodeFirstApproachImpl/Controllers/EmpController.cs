using JunBatchCodeFirstApproachImpl.Data;
using JunBatchCodeFirstApproachImpl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JunBatchCodeFirstApproachImpl.Controllers
{
    public class EmpController : Controller
    {
        ApplicationDbContext db;
        public EmpController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data = db.employee.Include(a => a.manager).ToList();
            return View(data);
        }

        [HttpPost]
        public IActionResult Index(string str)
        {
            if(str!=null)
            {
                var data = db.employee.Where(a => a.ename.Contains(str) || a.email.Contains(str) || a.esalary.ToString().Contains(str)).ToList();
                return View(data);
            }
            else
            {
                var data = db.employee.ToList();
                return View(data);
            }
            
        }

        public IActionResult AddEmp()
        {
            ViewBag.managers = new SelectList(db.Manager.ToList(), "Mid", "Mname");
            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(Emp e)
        {
            db.employee.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DelEmp(int id)
        {
            var d = db.employee.Find(id);
            //var d=db.employee.Where(b => b.eid.Equals(id)).FirstOrDefault();
            if(d!=null)
            {
                db.employee.Remove(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public IActionResult EditEmp(int id)
        {
            var data=db.employee.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult EditEmp(Emp e)
        {
            db.employee.Update(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
