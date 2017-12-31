using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class BodyCompositionsRepository : RepositoryAssociatedWithVisit<BodyCompositionEntity>,
        IBodyCompositionsRepository
    {
        public BodyCompositionsRepository(GeekMdSuiteDbContext context) : base(context)
        {
        }
    }
}