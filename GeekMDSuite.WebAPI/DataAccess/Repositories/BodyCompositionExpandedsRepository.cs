using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class BodyCompositionExpandedsRepository : RepositoryAssociatedWithVisit<BodyCompositionExpandedEntity>,
        IBodyCompositionExpandedsRepository
    {
        public BodyCompositionExpandedsRepository(GeekMdSuiteDbContext context) : base(context)
        {
        }
    }
}