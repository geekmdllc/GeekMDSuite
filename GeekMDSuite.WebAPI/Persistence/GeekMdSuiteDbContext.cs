using GeekMDSuite.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.Persistence
{
    public class GeekMdSuiteDbContext : DbContext
    {
        public GeekMdSuiteDbContext(DbContextOptions<GeekMdSuiteDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PatientEntity>().OwnsOne(p => p.Name);
            modelBuilder.Entity<PatientEntity>().OwnsOne(p => p.Gender);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=context.db");
        }
        
        public DbSet<PatientEntity> Patients { get; set; }
    }
}