using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JunBatchCodeFirstApproachImpl.Models
{
    public class Emp
    {
        [Key]
        public int eid { get; set; }
        public string ename { get; set; }
        public string email { get; set; }
        public double esalary { get; set; }

        [ForeignKey("manager")]
        public int Mid { get; set; }
        public Manager manager { get; set; }
    }
}
