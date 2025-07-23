using JunBatchCodeFirstApproachImpl.Data;
using JunBatchCodeFirstApproachImpl.Models;
using Microsoft.AspNetCore.Mvc;

namespace JunBatchCodeFirstApproachImpl.Controllers
{
    public class ManagerController : Controller
    {
        ApplicationDbContext db;
        public ManagerController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddManager()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddManager(Manager m)
        {
            db.Manager.Add(m);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult fetchmanager(Manager M)
        {
            var mans = db.Manager.ToList();
            return Json(mans);
        }
    }
}
