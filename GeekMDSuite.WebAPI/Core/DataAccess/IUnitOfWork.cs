using System;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;

namespace GeekMDSuite.WebAPI.Core.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IAudiogramsRepository Audiograms { get; }
        IBloodPressuresRepository BloodPressures { get; }
        ICarotidUltrasoundsRepository CarotidUltrasounds { get; }
        ICentralBloodPressureRepository CentralBloodPressures { get; }
        IFunctionalMovementScreensRepository FunctionalMovementScreens { get; }
        IGripStrengthsRepository GripStrengths { get; }
        IOcularPressuresRepository OcularPressures { get; }
        IPatientsRepository Patients { get; }
        IPeripheralVisionsRepository PeripheralVisions { get; }
        IVisitRepository Visits { get; }
        void Complete();
    }
}