using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData
{
    public interface IPatientsRepositoryAsync : IRepositoryAsync<PatientEntity>
    {
        Task<PatientEntity> FindByGuid(Guid guid);
        Task<IEnumerable<PatientEntity>> FilteredSearch(PatientDataSearchFilter filter);
    }
}