using System;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories
{
    public interface IRepositoryAssociatedWithVisit<T> : IRepository<T> where T:  class, IVisitData<T>
    {
        T FindByVisit(Guid visitGuid);
    }
}