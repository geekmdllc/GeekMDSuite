using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class VisualAcuitiesRepository : RepositoryAssociatedWithVisit<VisualAcuityEntity>, IVisualAcuitiesRepository
    {
        public VisualAcuitiesRepository(GeekMdSuiteDbContext context) : base(context)
        {
        }
    }
}