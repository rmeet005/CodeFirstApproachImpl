using JunBatchCodeFirstApproachImpl.Data;
using JunBatchCodeFirstApproachImpl.Models;
using JunBatchCodeFirstApproachImpl.Repository;

namespace JunBatchCodeFirstApproachImpl.Service
{
    public class EmpService : IEmpService
    {
        ApplicationDbContext db;
        public EmpService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddEmp(Emp e)
        {
            db.employee.Add(e);
            db.SaveChanges();
        }

        public List<Emp> displayEmp()
        {
            var data=db.employee.ToList();
            return data;
        }

        public void DeleteEmp(int id)
        {
            var d=db.employee.Find(id);
            db.employee.Remove(d);
            db.SaveChanges();
        }

        public Emp findEmpById(int id)
        {
            var data=db.employee.Find(id);
            return data;
        }

        public void UpdateEmpDetails(Emp e)
        {
            db.employee.Update(e);
            db.SaveChanges();
        }
    }
}
