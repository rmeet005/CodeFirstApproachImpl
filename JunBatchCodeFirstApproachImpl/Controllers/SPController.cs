using JunBatchCodeFirstApproachImpl.Data;
using JunBatchCodeFirstApproachImpl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JunBatchCodeFirstApproachImpl.Controllers
{
    public class SPController : Controller
    {
        ApplicationDbContext db;
        IWebHostEnvironment env;
        public SPController(ApplicationDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Addstudent()
        {
            
            return View();

        }
        [HttpPost]
        public IActionResult Addstudent(StudentModal s)
        {
            string path = env.WebRootPath;
            string filename = "Content/Images/" + s.Sphoto.FileName;
            string fpath=Path.Combine(path, filename);
            FileUpload(s.Sphoto, fpath);
            db.Database.ExecuteSqlRaw($"exec AddorUpdateStudent '{s.Sname}','{s.Scourse}','{s.fees}','{filename}'");
            return View();

        }

        public void FileUpload(IFormFile file,string path )
        {
            FileStream Stream = new FileStream(path,FileMode.Create);
            file.CopyTo( Stream );
        }

        public IActionResult Fetchstudent()
        {
                var data = db.Student.FromSqlRaw("exec fetchstud").ToList();
                return View(data);

        }
        public IActionResult EditStudent(int id) 
        {
            var d = db.Student.FromSqlRaw($"exec FindStudbyId1 '{id}'").ToList().SingleOrDefault();
            return View(d);
        }
    }
}
