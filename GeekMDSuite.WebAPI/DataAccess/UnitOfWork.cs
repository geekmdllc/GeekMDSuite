using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData;

namespace GeekMDSuite.WebAPI.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(GeekMdSuiteDbContext context)
        {
            _context = context;
            Audiograms = new AudiogramsRepository(_context);
            BloodPressures = new BloodPressuresRepository(_context);
            BodyCompositions = new BodyCompositionsRepository(_context);
            BodyCompositionExpandeds = new BodyCompositionExpandedsRepository(_context);
            CarotidUltrasounds = new CarotidUltrasoundsRepository(_context);
            CentralBloodPressures = new CentralBloodPressuresRepository(_context);
            FunctionalMovementScreens = new FunctionalMovementScreensRepository(_context);
            GripStrengths = new GripStrengthsRepository(_context);
            IshiharaSixPlates = new IshiharaSixPlatesRepository(_context);
            OccularPressures = new OccularPressuresRepository(_context);
            Patients = new PatientsRepository(_context);
            PeripheralVisions = new PeripheralVisionsRepository(_context);
            Pushups = new PushupsRepository(_context);
            SitAndReaches = new SitAndReachesRepository(_context);
            Situps = new SitupsRepository(_context);
            Spirometries = new SpirometriesRepository(_context);
            TreadmillExerciseStressTests = new TreadmillExerciseStressTestsRepository(_context);
            Visits = new VisitsRepository(_context);
            VisualAcuities = new VisualAcuitiesRepository(_context);
            VitalSigns = new VitalSignsRepository(_context);
        }

        public IRepositoryAssociatedWithVisit<T> VisitData<T>() where T : class, IVisitData<T> => new RepositoryAssociatedWithVisit<T>(_context);
        public IRepository<T> EntityData<T>() where T : class, IEntity<T> => new Repository<T>(_context);

        public IAudiogramsRepository Audiograms { get;  }
        public IBloodPressuresRepository BloodPressures { get;  }
        public IBodyCompositionsRepository BodyCompositions { get; set; }
        public IBodyCompositionExpandedsRepository BodyCompositionExpandeds { get; set; }
        public ICarotidUltrasoundsRepository CarotidUltrasounds { get; }
        public ICentralBloodPressureRepository CentralBloodPressures { get; }
        public IFunctionalMovementScreensRepository FunctionalMovementScreens { get; }
        public IGripStrengthsRepository GripStrengths { get;  }
        public IIshiharaSixPlatesRepository IshiharaSixPlates { get; set; }
        public IOccularPressuresRepository OccularPressures { get; }
        public IPatientsRepository Patients { get; }
        public IPeripheralVisionsRepository PeripheralVisions { get; }
        public IPushupsRepository Pushups { get; }
        public ISitAndReachesRepository SitAndReaches { get; }
        public ISitupsRepository Situps { get; set; }
        public ISpirometriesRepository Spirometries { get; set; }
        public ITreadmillExerciseStressTestsRepository TreadmillExerciseStressTests { get; set; }
        public IVisitsRepository Visits { get;  }
        public IVisualAcuitiesRepository VisualAcuities { get; set; }
        public IVitalSignsRepository VitalSigns { get; set; }

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