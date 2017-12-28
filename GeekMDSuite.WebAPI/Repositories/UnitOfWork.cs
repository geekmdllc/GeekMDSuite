using GeekMDSuite.WebAPI.Persistence;

namespace GeekMDSuite.WebAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(GeekMdSuiteDbContext context)
        {
            _context = context;
            Patients = new PatientRepository(_context);
        }

        public IPatientRepository Patients { get; }

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