using System.ComponentModel.DataAnnotations;

namespace JunBatchCodeFirstApproachImpl.Models
{
    public class Student
    {
        [Key]
        public int Sid { get; set; }
        public string? Sname { get; set; }
        public string? Scourse { get; set; }
        public double fees { get; set; }
        public string? Sphoto { get; set; }
    }
}
