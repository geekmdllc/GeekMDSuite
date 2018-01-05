using GeekMDSuite.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Context
{
    public partial class GeekMdSuiteDbContext
    {
        private static void ConfigurePatientEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().OwnsOne(p => p.Name);
            modelBuilder.Entity<Patient>().OwnsOne(p => p.Gender);
            modelBuilder.Entity<Patient>().OwnsOne(p => p.Comorbidities);
            modelBuilder.Entity<Patient>().HasIndex(p => p.Guid).IsUnique();
            modelBuilder.Entity<Patient>().HasIndex(p => p.MedicalRecordNumber).IsUnique();
        }
    }
}