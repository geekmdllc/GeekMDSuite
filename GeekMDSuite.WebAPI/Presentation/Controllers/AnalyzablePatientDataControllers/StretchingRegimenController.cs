using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    [Produces("application/json", "application/xml")]
    public class StretchingRegimenController : VisitDataController<StretchingRegimenEntity>
    {
        public StretchingRegimenController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}