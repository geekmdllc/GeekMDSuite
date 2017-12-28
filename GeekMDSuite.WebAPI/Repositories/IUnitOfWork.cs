using System;

namespace GeekMDSuite.WebAPI.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patients { get; }
        void Complete();
    }
}