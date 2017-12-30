using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Repositories;

namespace GeekMDSuite.WebAPI.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(GeekMdSuiteDbContext context)
        {
            _context = context;
            Patients = new PatientsRepository(_context);
            Audiograms = new AudiogramRepository(_context);
            CarotidUltrasounds = new CarotidUltrasoundsRepository(_context);
            CentralBloodPressures = new CentralBloodPressuresRepository(_context);
        }

        public IPatientsRepository Patients { get; }
        public IAudiogramRepository Audiograms { get;  }
        public ICarotidUltrasoundsRepository CarotidUltrasounds { get; }
        public ICentralBloodPressureRepository CentralBloodPressures { get; }

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