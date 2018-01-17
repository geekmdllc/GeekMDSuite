using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData
{
    public interface IRepositoryAssociatedWithVisitAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IVisitData
    {
        Task<IEnumerable<TEntity>> FindByVisit(Guid visitGuid);
        Task<IEnumerable<TEntity>> FindByPatient(Guid paitentGuid);
    }
}