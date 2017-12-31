using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class PeripheralVisionsRepository : RepositoryAssociatedWithVisit<PeripheralVisionEntity>, IPeripheralVisionsRepository
    {
        public PeripheralVisionsRepository(GeekMdSuiteDbContext context) : base(context)
        {
        }
    }
}