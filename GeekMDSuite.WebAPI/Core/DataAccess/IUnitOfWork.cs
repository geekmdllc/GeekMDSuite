using System;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.Models;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace GeekMDSuite.WebAPI.Core.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class, IEntity<T>;
        IAudiogramsRepository Audiograms { get; }
        IBloodPressuresRepository BloodPressures { get; }
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
        IVisitRepository Visits { get; }
        void Complete();
    }
}