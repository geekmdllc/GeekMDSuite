using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData
{
    public interface IVisitsRepositoryAsync : IRepositoryAssociatedWithVisitAsync<VisitEntity>
    {
        Task<IEnumerable<VisitEntity>> Search(VisitDataSearchFilter filter);
    }
}