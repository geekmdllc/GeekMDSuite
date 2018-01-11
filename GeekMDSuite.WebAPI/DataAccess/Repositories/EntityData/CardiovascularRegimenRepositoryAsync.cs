using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class CardiovascularRegimenRepositoryAsync : RepositoryAssociatedWithVisitAsync<CardiovascularRegimenEntity>, ICardiovascularRegimenRepositoryAsync
    {
        public CardiovascularRegimenRepositoryAsync(GeekMdSuiteDbContext context) : base(context)
        {
        }
    }
}