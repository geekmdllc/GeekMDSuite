using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData;

namespace GeekMDSuite.WebAPI.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GeekMdSuiteDbContext _context;

        public UnitOfWork(GeekMdSuiteDbContext context)
        {
            _context = context;
            Audiograms = new AudiogramsRepositoryAsync(_context);
            BloodPressures = new BloodPressuresRepositoryAsync(_context);
            BodyCompositions = new BodyCompositionsRepositoryAsync(_context);
            BodyCompositionExpandeds = new BodyCompositionExpandedsRepositoryAsync(_context);
            CarotidUltrasounds = new CarotidUltrasoundsRepositoryAsync(_context);
            CentralBloodPressures = new CentralBloodPressuresRepositoryAsync(_context);
            CardiovascularRegimens = new CardiovascularRegimenRepositoryAsync(_context);
            FunctionalMovementScreens = new FunctionalMovementScreensRepositoryAsync(_context);
            GripStrengths = new GripStrengthsRepositoryAsync(_context);
            IshiharaSixPlates = new IshiharaSixPlatesRepositoryAsync(_context);
            OccularPressures = new OccularPressuresRepositoryAsync(_context);
            Patients = new PatientsRepositoryAsync(_context);
            PeripheralVisions = new PeripheralVisionsRepositoryAsync(_context);
            Pushups = new PushupsRepositoryAsync(_context);
            ResistanceRegimens = new ResistanceRegimenRepostoryAsync(_context);
            SitAndReaches = new SitAndReachesRepositoryAsync(_context);
            Situps = new SitupsRepositoryAsync(_context);
            StretchingRegimens = new StretchingRegimenRepositoryAsync(_context);
            Spirometries = new SpirometriesRepositoryAsync(_context);
            TreadmillExerciseStressTests = new TreadmillExerciseStressTestsRepositoryAsync(_context);
            Visits = new VisitsRepositoryAsync(_context);
            VisualAcuities = new VisualAcuitiesRepositoryAsync(_context);
            VitalSigns = new VitalSignsRepositoryAsync(_context);
        }


        public IRepositoryAssociatedWithVisitAsync<T> VisitData<T>() where T : class, IMapProperties<T>, IVisitData
        {
            return new RepositoryAssociatedWithVisitAsync<T>(_context);
        }

        public IRepositoryAsync<T> EntityData<T>() where T : class, IMapProperties<T>, IEntity
        {
            return new RepositoryAsync<T>(_context);
        }

        public IAudiogramsRepositoryAsync Audiograms { get; }
        public IBloodPressuresRepositoryAsync BloodPressures { get; }
        public IBodyCompositionsRepositoryAsync BodyCompositions { get; set; }
        public IBodyCompositionExpandedsRepositoryAsync BodyCompositionExpandeds { get; set; }
        public ICardiovascularRegimenRepositoryAsync CardiovascularRegimens { get; set; }
        public ICarotidUltrasoundsRepositoryAsync CarotidUltrasounds { get; }
        public ICentralBloodPressureRepositoryAsync CentralBloodPressures { get; }
        public IFunctionalMovementScreensRepositoryAsync FunctionalMovementScreens { get; }
        public IGripStrengthsRepositoryAsync GripStrengths { get; }
        public IIshiharaSixPlatesRepositoryAsync IshiharaSixPlates { get; set; }
        public IOccularPressuresRepositoryAsync OccularPressures { get; }
        public IResistanceRegimenRepositoryAsync ResistanceRegimens { get; }
        public IPatientsRepositoryAsync Patients { get; }
        public IPeripheralVisionsRepositoryAsync PeripheralVisions { get; }
        public IPushupsRepositoryAsync Pushups { get; }
        public ISitAndReachesRepositoryAsync SitAndReaches { get; }
        public ISitupsRepositoryAsync Situps { get; set; }
        public ISpirometriesRepositoryAsync Spirometries { get; set; }
        public IStretchingRegimenRepositoryAsync StretchingRegimens { get; set; }
        public ITreadmillExerciseStressTestsRepositoryAsync TreadmillExerciseStressTests { get; set; }
        public IVisitsRepositoryAsync Visits { get; }
        public IVisualAcuitiesRepositoryAsync VisualAcuities { get; set; }
        public IVitalSignsRepositoryAsync VitalSigns { get; set; }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}