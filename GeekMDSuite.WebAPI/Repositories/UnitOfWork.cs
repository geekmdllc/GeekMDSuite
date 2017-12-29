using GeekMDSuite.WebAPI.Persistence;

namespace GeekMDSuite.WebAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(GeekMdSuiteDbContext context)
        {
            _context = context;
            Patients = new PatientsRepository(_context);
            Audiograms = new AudiogramRepository(_context);
        }

        public IPatientsRepository Patients { get; }
        public IAudiogramRepository Audiograms { get;  }

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