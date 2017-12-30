using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class FunctionalMovementScreensRepository : Repository<FunctionalMovementScreenEntity>, IFunctionalMovementScreensRepository
    {
        public FunctionalMovementScreensRepository(GeekMdSuiteDbContext context) : base (context)
        {
            
        }
    }
}