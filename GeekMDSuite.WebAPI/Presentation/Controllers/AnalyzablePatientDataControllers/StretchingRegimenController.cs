using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities;
using GeekMDSuite.WebAPI.Presentation.ResourceModels;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using GeekMDSuite.WebAPI.Presentation.StubModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    [Produces("application/json", "application/xml")]
    public class StretchingRegimenController : VisitDataController<StretchingRegimenEntity, StretchingRegimenStub, StretchingRegimenStubFromUser, StretchingRegimenResource, StretchingRegimenController>
    {
        public StretchingRegimenController(IUnitOfWork unitOfWork, IMapper mapper, IUrlHelper urlHelper) : base(unitOfWork, mapper, urlHelper)
        {
        }
    }
}