using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Context
{
    public partial class GeekMdSuiteDbContext
    {
        private static void ConfigureBodyCompositionExpandedEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BodyCompositionExpandedEntity>().OwnsOne(bce => bce.Height);
            modelBuilder.Entity<BodyCompositionExpandedEntity>().OwnsOne(bce => bce.Waist);
            modelBuilder.Entity<BodyCompositionExpandedEntity>().OwnsOne(bce => bce.Hips);
            modelBuilder.Entity<BodyCompositionExpandedEntity>().OwnsOne(bce => bce.Weight);
        }
    }
}