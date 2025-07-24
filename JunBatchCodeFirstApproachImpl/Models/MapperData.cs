using AutoMapper;

namespace JunBatchCodeFirstApproachImpl.Models
{
    public class MapperData:Profile
    {
       public MapperData()
        {
            CreateMap<Employee, EmployeeDto>().ForMember(x=>x.Mname,x=>x.MapFrom(x=>x.manager!=null?x.manager.Mname:"No")).ReverseMap();
        }
    }
}
