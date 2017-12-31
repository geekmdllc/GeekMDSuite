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
        IPatientsRepository Patients { get; }
        IVisitRepository Visits { get; }
        void Complete();
    }
}