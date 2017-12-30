using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Context
{
    public partial class GeekMdSuiteDbContext
    {
        private static void ConfigureFunctionalMovementScreen(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FunctionalMovementScreenEntity>().OwnsOne(fms => fms.ActiveStraightLegRaise, fmsd =>
            {
                fmsd.OwnsOne(laterality => laterality.Left);
                fmsd.OwnsOne(laterality => laterality.Right);
            });
            modelBuilder.Entity<FunctionalMovementScreenEntity>().OwnsOne(fms => fms.DeepSquat);
            modelBuilder.Entity<FunctionalMovementScreenEntity>().OwnsOne(fms => fms.HurdleStep, fmsd =>
            {
                fmsd.OwnsOne(laterality => laterality.Left);
                fmsd.OwnsOne(laterality => laterality.Right);
            });
            modelBuilder.Entity<FunctionalMovementScreenEntity>().OwnsOne(fms => fms.InlineLunge, fmsd =>
            {
                fmsd.OwnsOne(laterality => laterality.Left);
                fmsd.OwnsOne(laterality => laterality.Right);
            });
            modelBuilder.Entity<FunctionalMovementScreenEntity>().OwnsOne(fms => fms.RotaryStability, fmsd =>
            {
                fmsd.OwnsOne(laterality => laterality.Left);
                fmsd.OwnsOne(laterality => laterality.Right);
            });
            modelBuilder.Entity<FunctionalMovementScreenEntity>().OwnsOne(fms => fms.ShoulderMobility, fmsd =>
            {
                fmsd.OwnsOne(laterality => laterality.Left);
                fmsd.OwnsOne(laterality => laterality.Right);
            });
            modelBuilder.Entity<FunctionalMovementScreenEntity>().OwnsOne(fms => fms.TrunkStabilityPushup);
        }
    }
}