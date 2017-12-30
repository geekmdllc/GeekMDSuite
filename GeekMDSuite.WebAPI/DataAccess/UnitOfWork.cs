using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.DataAccess.Repositories;

namespace GeekMDSuite.WebAPI.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(GeekMdSuiteDbContext context)
        {
            _context = context;
            Audiograms = new AudiogramRepository(_context);
            BloodPressures = new BloodPressuresRepository(_context);
            CarotidUltrasounds = new CarotidUltrasoundsRepository(_context);
            CentralBloodPressures = new CentralBloodPressuresRepository(_context);
            FunctionalMovementScreens = new FunctionalMovementScreensRepository(_context);
            Patients = new PatientsRepository(_context);
            Visits = new VisitsRepository(_context);
        }

        public IAudiogramRepository Audiograms { get;  }
        public IBloodPressuresRepository BloodPressures { get;  }
        public ICarotidUltrasoundsRepository CarotidUltrasounds { get; }
        public ICentralBloodPressureRepository CentralBloodPressures { get; }
        public IFunctionalMovementScreensRepository FunctionalMovementScreens { get; }
        public IPatientsRepository Patients { get; }
        public IVisitRepository Visits { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
        
        private readonly GeekMdSuiteDbContext _context;
    }
}