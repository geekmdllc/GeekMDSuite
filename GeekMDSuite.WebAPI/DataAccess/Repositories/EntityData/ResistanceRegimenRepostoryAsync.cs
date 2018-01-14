using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class ResistanceRegimenRepostoryAsync : RepositoryAssociatedWithVisitAsync<ResistanceRegimenEntity>,
        IResistanceRegimenRepositoryAsync
    {
        public ResistanceRegimenRepostoryAsync(GeekMdSuiteDbContext context) : base(context)
        {
        }
    }
}