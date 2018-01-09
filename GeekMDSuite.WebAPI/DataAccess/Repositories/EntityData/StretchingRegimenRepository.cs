using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class StretchingRegimenRepository : RepositoryAssociatedWithVisit<StretchingRegimenEntity>,
        IStretchingRegimenRepository
    {
        public StretchingRegimenRepository(GeekMdSuiteDbContext context) : base(context)
        {
        }
    }
}