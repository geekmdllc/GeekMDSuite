using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData
{
    public interface IVisitsRepositoryAsync : IRepositoryAsync<VisitEntity>
    {
        Task<IEnumerable<VisitEntity>> FilteredSearch(VisitDataSearchFilter filter);
        Task<VisitEntity> FindByGuid(Guid guid);
        Task<IEnumerable<VisitEntity>> FindByPatient(Guid guid);
    }
}