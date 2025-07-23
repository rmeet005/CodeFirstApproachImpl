using System.ComponentModel.DataAnnotations;

namespace JunBatchCodeFirstApproachImpl.Models
{
    public class Manager
    {
        [Key]
        public int Mid { get; set; }
        public string Mname { get; set; }

        public List<Emp> emps { get; set; }
    }
}
