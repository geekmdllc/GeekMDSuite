using System;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;

namespace GeekMDSuite.WebAPI.Core.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IAudiogramRepository Audiograms { get; }
        IBloodPressuresRepository BloodPressures { get; }
        ICarotidUltrasoundsRepository CarotidUltrasounds { get; }
        ICentralBloodPressureRepository CentralBloodPressures { get; }
        IFunctionalMovementScreensRepository FunctionalMovementScreens { get; }
        IPatientsRepository Patients { get; }
        void Complete();
    }
}