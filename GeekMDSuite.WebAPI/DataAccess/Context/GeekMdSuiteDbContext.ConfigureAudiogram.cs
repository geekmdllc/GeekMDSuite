using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Context
{
    public partial class GeekMdSuiteDbContext
    {
        private static void ConfigureAudiogramEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AudiogramEntity>().OwnsOne(agDataset => agDataset.Left, dataset =>
            {
                dataset.OwnsOne(f => f.F125);
                dataset.OwnsOne(f => f.F250);
                dataset.OwnsOne(f => f.F500);
                dataset.OwnsOne(f => f.F1000);
                dataset.OwnsOne(f => f.F2000);
                dataset.OwnsOne(f => f.F3000);
                dataset.OwnsOne(f => f.F4000);
                dataset.OwnsOne(f => f.F6000);
                dataset.OwnsOne(f => f.F8000);
            });
            modelBuilder.Entity<AudiogramEntity>().OwnsOne(agDataset => agDataset.Right, dataset =>
            {
                dataset.OwnsOne(f => f.F125);
                dataset.OwnsOne(f => f.F250);
                dataset.OwnsOne(f => f.F500);
                dataset.OwnsOne(f => f.F1000);
                dataset.OwnsOne(f => f.F2000);
                dataset.OwnsOne(f => f.F3000);
                dataset.OwnsOne(f => f.F4000);
                dataset.OwnsOne(f => f.F6000);
                dataset.OwnsOne(f => f.F8000);
            });
        }
    }
}