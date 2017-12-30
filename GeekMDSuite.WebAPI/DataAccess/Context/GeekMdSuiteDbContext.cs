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
        public virtual DbSet<CarotidUltrasoundEntity> CarotidUltrasounds { get; set; }
        public virtual DbSet<CentralBloodPressureEntity> CentralBloodPressures { get; set; }
        public virtual DbSet<FunctionalMovementScreenEntity> FunctionalMovementScreens { get; set; }
        public virtual DbSet<PatientEntity> Patients { get; set; }
        public virtual DbSet<VisitEntity> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureAudiogramEntity(modelBuilder);
            ConfigureCarotidUltrasoundEntity(modelBuilder);
            ConfigureFunctionalMovementScreen(modelBuilder);
            ConfigurePatientEntity(modelBuilder);
        }
    }
}