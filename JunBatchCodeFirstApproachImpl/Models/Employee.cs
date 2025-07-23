using System.ComponentModel.DataAnnotations;

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
    }
}
