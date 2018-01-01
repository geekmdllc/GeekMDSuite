using System;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Core.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryAssociatedWithVisit<T> VisitDataRepository<T>() where T : class, IVisitData<T>;
        IRepository<T> EntityDataRepository<T>() where T : class, IEntity<T>;
        IAudiogramsRepository Audiograms { get; }
        IBloodPressuresRepository BloodPressures { get; }
        IBodyCompositionsRepository BodyCompositions { get; }
        IBodyCompositionExpandedsRepository BodyCompositionExpandeds { get; }
        ICarotidUltrasoundsRepository CarotidUltrasounds { get; }
        ICentralBloodPressureRepository CentralBloodPressures { get; }
        IFunctionalMovementScreensRepository FunctionalMovementScreens { get; }
        IGripStrengthsRepository GripStrengths { get; }
        IOccularPressuresRepository OccularPressures { get; }
        IPatientsRepository Patients { get; }
        IPeripheralVisionsRepository PeripheralVisions { get; }
        IPushupsRepository Pushups { get; }
        ISitAndReachesRepository SitAndReaches { get; }
        ISitupsRepository Situps { get; }
        ISpirometriesRepository Spirometries { get; }
        ITreadmillExerciseStressTestsRepository TreadmillExerciseStressTests { get; }
        IVisitsRepository Visits { get; }
        IVisualAcuitiesRepository VisualAcuities { get; }
        IVitalSignsRepository VitalSigns { get; }
        void Complete();
    }
}