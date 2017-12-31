using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Context
{
    public partial class GeekMdSuiteDbContext
    {
        private static void ConfigureGripStrengthEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GripStrengthEntity>().OwnsOne(gse => gse.Left);
            modelBuilder.Entity<GripStrengthEntity>().OwnsOne(gse => gse.Right);
        }
    }
}