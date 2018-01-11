using System;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Core.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IAudiogramsRepositoryAsync Audiograms { get; }
        IBloodPressuresRepositoryAsync BloodPressures { get; }
        IBodyCompositionsRepositoryAsync BodyCompositions { get; }
        IBodyCompositionExpandedsRepositoryAsync BodyCompositionExpandeds { get; }
        ICarotidUltrasoundsRepositoryAsync CarotidUltrasounds { get; }
        ICentralBloodPressureRepositoryAsync CentralBloodPressures { get; }
        IFunctionalMovementScreensRepositoryAsync FunctionalMovementScreens { get; }
        IGripStrengthsRepositoryAsync GripStrengths { get; }
        IIshiharaSixPlatesRepositoryAsync IshiharaSixPlates { get; }
        IOccularPressuresRepositoryAsync OccularPressures { get; }
        IPatientsRepositoryAsync Patients { get; }
        IPeripheralVisionsRepositoryAsync PeripheralVisions { get; }
        IPushupsRepositoryAsync Pushups { get; }
        ISitAndReachesRepositoryAsync SitAndReaches { get; }
        ISitupsRepositoryAsync Situps { get; }
        ISpirometriesRepositoryAsync Spirometries { get; }
        ITreadmillExerciseStressTestsRepositoryAsync TreadmillExerciseStressTests { get; }
        IVisitsRepositoryAsync Visits { get; }
        IVisualAcuitiesRepositoryAsync VisualAcuities { get; }
        IVitalSignsRepositoryAsync VitalSigns { get; }
        IResistanceRegimenRepositoryAsync ResistanceRegimens { get; }
        ICardiovascularRegimenRepositoryAsync CardiovascularRegimens { get; }
        IStretchingRegimenRepositoryAsync StretchingRegimens { get; }
        
        IRepositoryAssociatedWithVisitAsync<T> VisitData<T>() where T : class, IVisitData<T>;
        IRepositoryAsync<T> EntityData<T>() where T : class, IEntity<T>;
        Task Complete();
    }
}