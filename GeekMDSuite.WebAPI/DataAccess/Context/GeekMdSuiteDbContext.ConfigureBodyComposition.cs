using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Context
{
    public partial class GeekMdSuiteDbContext
    {
        private static void ConfigureBodyCompositionEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BodyCompositionEntity>().OwnsOne(bce => bce.Height);
            modelBuilder.Entity<BodyCompositionEntity>().OwnsOne(bce => bce.Waist);
            modelBuilder.Entity<BodyCompositionEntity>().OwnsOne(bce => bce.Hips);
            modelBuilder.Entity<BodyCompositionEntity>().OwnsOne(bce => bce.Weight);
        }
    }
}