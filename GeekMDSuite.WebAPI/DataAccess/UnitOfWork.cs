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
            Context = context;
            Audiograms = new AudiogramsRepository(Context);
            BloodPressures = new BloodPressuresRepository(Context);
            CarotidUltrasounds = new CarotidUltrasoundsRepository(Context);
            CentralBloodPressures = new CentralBloodPressuresRepository(Context);
            FunctionalMovementScreens = new FunctionalMovementScreensRepository(Context);
            GripStrengths = new GripStrengthsRepository(Context);
            OcularPressures = new OcularPressuresRepository(Context);
            Patients = new PatientsRepository(Context);
            Visits = new VisitsRepository(Context);
            PeripheralVisions = new PeripheralVisionsRepository(Context);
        }

        public IAudiogramsRepository Audiograms { get;  }
        public IBloodPressuresRepository BloodPressures { get;  }
        public ICarotidUltrasoundsRepository CarotidUltrasounds { get; }
        public ICentralBloodPressureRepository CentralBloodPressures { get; }
        public IFunctionalMovementScreensRepository FunctionalMovementScreens { get; }
        public IGripStrengthsRepository GripStrengths { get;  }
        public IOcularPressuresRepository OcularPressures { get; }
        public IPatientsRepository Patients { get; }
        public IPeripheralVisionsRepository PeripheralVisions { get; set; }
        public IVisitRepository Visits { get;  }

        public void Complete()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
        
        protected readonly GeekMdSuiteDbContext Context;
    }
}