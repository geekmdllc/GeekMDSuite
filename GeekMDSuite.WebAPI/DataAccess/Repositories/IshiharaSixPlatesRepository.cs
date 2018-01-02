using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class IshiharaSixPlatesRepository : RepositoryAssociatedWithVisit<IshiharaSixPlateEntity>,
        IIshiharaSixPlatesRepository
    {
        public IshiharaSixPlatesRepository(GeekMdSuiteDbContext context) : base(context)
        {
        }
    }
}