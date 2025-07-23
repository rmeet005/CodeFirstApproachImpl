using JunBatchCodeFirstApproachImpl.Models;
using JunBatchCodeFirstApproachImpl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JunBatchCodeFirstApproachImpl.Controllers
{
    public class RepoController : Controller
    {
        IEmpService service;
        public RepoController(IEmpService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            var data=service.displayEmp();
            return View(data);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Emp e)
        {
            service.AddEmp(e);
            return RedirectToAction("Index");
        }

        public IActionResult DelEmp(int id)
        {
            service.DeleteEmp(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditEmp(int id)
        {
            var data=service.findEmpById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult EditEmp(Emp e)
        {
            service.UpdateEmpDetails(e);
            return RedirectToAction("Index");
        }
    }
}
