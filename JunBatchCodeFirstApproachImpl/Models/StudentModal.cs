namespace JunBatchCodeFirstApproachImpl.Models
{
    public class StudentModal
    {
        public int Sid { get; set; }
        public string? Sname { get; set; }
        public string? Scourse { get; set; }
        public double fees { get; set; }
        public IFormFile Sphoto { get; set; }
    }
}
