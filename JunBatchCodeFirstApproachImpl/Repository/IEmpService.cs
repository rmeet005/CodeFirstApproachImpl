using JunBatchCodeFirstApproachImpl.Models;

namespace JunBatchCodeFirstApproachImpl.Repository
{
    public interface IEmpService
    {
        void AddEmp(Emp e);
        List<Emp> displayEmp();
        void DeleteEmp(int id);

        Emp findEmpById(int id);
        void UpdateEmpDetails(Emp e);
    }
}
