using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Context
{
    public partial class GeekMdSuiteDbContext
    {
        private static void ConfigureVitalSignsEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VitalSignsEntity>().OwnsOne(vse => vse.Temperature);
            modelBuilder.Entity<VitalSignsEntity>().OwnsOne(vse => vse.BloodPressure);
        }
    }
}