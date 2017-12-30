using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Context
{
    public partial class GeekMdSuiteDbContext
    {
        private static void ConfigureCarotidUltrasoundEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarotidUltrasoundEntity>().OwnsOne(cu => cu.Left);
            modelBuilder.Entity<CarotidUltrasoundEntity>().OwnsOne(cu => cu.Right);
        }
    }
}