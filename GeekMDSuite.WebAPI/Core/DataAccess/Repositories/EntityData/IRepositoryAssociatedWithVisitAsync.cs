using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData
{
    public interface IRepositoryAssociatedWithVisitAsync<T> : IRepositoryAsync<T> where T : class, IVisitData
    {
        Task<IEnumerable<T>> FindByVisit(Guid visitGuid);
    }
}