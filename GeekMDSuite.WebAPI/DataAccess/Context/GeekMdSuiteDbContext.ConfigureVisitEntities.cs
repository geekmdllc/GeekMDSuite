using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Context
{
    public partial class GeekMdSuiteDbContext
    {
        private static void ConfigureVisitEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisitEntity>().HasIndex(v => v.VisitGuid).IsUnique();
        }
    }
}