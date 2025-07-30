using JunBatchCodeFirstApproachImpl.Models;
using Microsoft.EntityFrameworkCore;

namespace JunBatchCodeFirstApproachImpl.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Emp> employee { get; set; }
        public DbSet<Manager> Manager { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}
