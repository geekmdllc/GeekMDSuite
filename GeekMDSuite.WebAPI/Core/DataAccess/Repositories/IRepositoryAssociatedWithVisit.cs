using System;
using System.Collections.Generic;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories
{
    public interface IRepositoryAssociatedWithVisit<T> : IRepository<T> where T:  class, IVisitData<T>
    {
        IEnumerable<T> FindByVisit(Guid visitGuid);
        IEnumerable<T> FindByPatientGuid(Guid patientGuid);
    }
}