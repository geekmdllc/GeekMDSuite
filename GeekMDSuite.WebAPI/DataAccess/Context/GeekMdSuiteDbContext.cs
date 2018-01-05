using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Context
{
    public partial class GeekMdSuiteDbContext : DbContext
    {
        public GeekMdSuiteDbContext() {}
        public GeekMdSuiteDbContext(DbContextOptions<GeekMdSuiteDbContext> options) : base(options) {}

        public virtual DbSet<AudiogramEntity> Audiograms { get; set; }
        public virtual DbSet<BloodPressureEntity> BloodPressures { get; set; }
        public virtual DbSet<BodyCompositionEntity> BodyCompositions { get; set; }
        public virtual DbSet<BodyCompositionExpandedEntity> BodyCompositionExpandeds { get; set; }
        public virtual DbSet<CarotidUltrasoundEntity> CarotidUltrasounds { get; set; }
        public virtual DbSet<CentralBloodPressureEntity> CentralBloodPressures { get; set; }
        public virtual DbSet<FunctionalMovementScreenEntity> FunctionalMovementScreens { get; set; }
        public virtual DbSet<GripStrengthEntity> GripStrengths { get; set; }
        public virtual DbSet<IshiharaSixPlateEntity> IshiharaSixPlates { get; set; }
        public virtual DbSet<OcularPressureEntity> OcularPressures { get; set; }
        public virtual DbSet<PeripheralVisionEntity> PeripheralVisions { get; set; }
        public virtual DbSet<PushupsEntity> Pushups { get; set; }
        public virtual DbSet<SitAndReachEntity> SitAndReaches { get; set; }
        public virtual DbSet<SitupsEntity> Situps { get; set; }
        public virtual DbSet<SpirometryEntity> Spirometries { get; set; }
        public virtual DbSet<TreadmillExerciseStressTestEntity> TreadmillExerciseStressTests { get; set; }
        public virtual DbSet<VisitEntity> Visits { get; set; }
        public virtual DbSet<VisualAcuityEntity> VisualAcuities { get; set; }
        public virtual DbSet<VitalSignsEntity> VitalSigns { get; set; }
        
        //refactored
        public virtual DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureAudiogramEntity(modelBuilder);
            ConfigureBodyCompositionEntity(modelBuilder);
            ConfigureBodyCompositionExpandedEntity(modelBuilder);
            ConfigureCarotidUltrasoundEntity(modelBuilder);
            ConfigureFunctionalMovementScreen(modelBuilder);
            ConfigureGripStrengthEntity(modelBuilder);
            ConfigureIshiharaSixPlateEntities(modelBuilder);
            ConfigurePatientEntity(modelBuilder);
            ConfigureTreadmillExerciseStressTestEntity(modelBuilder);
            ConfigureVitalSignsEntity(modelBuilder);
            ConfigureVisitEntities(modelBuilder);
        }
    }
}