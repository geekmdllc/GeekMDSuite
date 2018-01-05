using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Context
{
    public partial class GeekMdSuiteDbContext
    {
        private static void ConfigurePatientEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientEntity>().OwnsOne(p => p.Name);
            modelBuilder.Entity<PatientEntity>().OwnsOne(p => p.Gender);
            modelBuilder.Entity<PatientEntity>().HasIndex(p => p.Guid).IsUnique();
            modelBuilder.Entity<PatientEntity>().HasIndex(p => p.MedicalRecordNumber).IsUnique();
            modelBuilder.Entity<PatientEntity>().Property(p => p.Comorbidities);
        }
    }
}