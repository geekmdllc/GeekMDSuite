using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Context
{
    public partial class GeekMdSuiteDbContext
    {
        private static void ConfigureIshiharaSixPlateEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IshiharaSixPlateEntity>().OwnsOne(e => e.Plate1);
            modelBuilder.Entity<IshiharaSixPlateEntity>().OwnsOne(e => e.Plate2);
            modelBuilder.Entity<IshiharaSixPlateEntity>().OwnsOne(e => e.Plate3);
            modelBuilder.Entity<IshiharaSixPlateEntity>().OwnsOne(e => e.Plate4);
            modelBuilder.Entity<IshiharaSixPlateEntity>().OwnsOne(e => e.Plate5);
            modelBuilder.Entity<IshiharaSixPlateEntity>().OwnsOne(e => e.Plate6);
        }
    }
}