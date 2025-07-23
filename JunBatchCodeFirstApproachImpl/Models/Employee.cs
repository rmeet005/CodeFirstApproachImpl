using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JunBatchCodeFirstApproachImpl.Models
{
    public class Employee
    {
        [Key]       
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string Role { get; set; }

        public double salary { get; set; }
        [ForeignKey("manager")]
        public int Mid { get; set; }

        public Manager manager { get; set; }
    }
}
