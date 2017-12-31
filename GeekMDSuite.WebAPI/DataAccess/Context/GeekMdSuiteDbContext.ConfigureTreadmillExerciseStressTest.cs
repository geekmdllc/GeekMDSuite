using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Context
{
    public partial class GeekMdSuiteDbContext
    {
        private static void ConfigureTreadmillExerciseStressTestEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TreadmillExerciseStressTestEntity>().OwnsOne(tmst => tmst.MaximumBloodPressure);
            modelBuilder.Entity<TreadmillExerciseStressTestEntity>().OwnsOne(tmst => tmst.Time);
            modelBuilder.Entity<TreadmillExerciseStressTestEntity>().OwnsOne(tmst => tmst.SupineBloodPressure);
        }
    }
}