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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>()
                .HasMany(m => m.employees)
                .WithOne(e => e.manager)
                .HasForeignKey(e => e.Mid)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
     

    }
