using System;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Repositories;

namespace GeekMDSuite.WebAPI.Core.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientsRepository Patients { get; }
        IAudiogramRepository Audiograms { get; }
        ICarotidUltrasoundsRepository CarotidUltrasounds { get; }
        ICentralBloodPressureRepository CentralBloodPressures { get; }
        IFunctionalMovementScreensRepository FunctionalMovementScreens { get; }
        void Complete();
    }
}