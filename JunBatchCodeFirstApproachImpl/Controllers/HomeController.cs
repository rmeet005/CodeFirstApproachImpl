using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JunBatchCodeFirstApproachImpl.Models;
using JunBatchCodeFirstApproachImpl.Data;
using Microsoft.EntityFrameworkCore;

namespace JunBatchCodeFirstApproachImpl.Controllers;

public class HomeController : Controller
{
    ApplicationDbContext db;
    public HomeController(ApplicationDbContext db)
    {
        this.db = db;
    }

    public IActionResult fetchdatas()
    {
        var data = db.employee.Include(x => x.manager).Select(e => new EmpDto
        {
            eid = e.eid,
            ename=e.ename,
            email=e.email,
            esalary=e.esalary,
            mid=e.Mid,
            mname=e.manager.Mname

        });
        return Json(data);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
