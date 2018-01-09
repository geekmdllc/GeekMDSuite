using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData
{
    public interface IRepositoryAssociatedWithVisit<T> : IRepository<T> where T : class, IVisitData<T>
    {
        Task<IEnumerable<T>> FindByVisit(Guid visitGuid);
        Task<IEnumerable<T>> FindByPatientGuid(Guid patientGuid);
        Task<IEnumerable<T>> FindByMedicalRecordNumber(string mrn);
        Task<IEnumerable<T>> FindByName(string name);
        Task<IEnumerable<T>> FindByDateOfBirth(DateTime dateOfBirth);
    }
}