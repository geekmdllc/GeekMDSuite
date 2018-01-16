using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.ResourceModels;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using GeekMDSuite.WebAPI.Presentation.StubModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    [Produces("application/json", "application/xml")]
    public class CarotidUltrasoundController : VisitDataController<CarotidUltrasoundEntity, CarotidUltrasoundStub, CarotidUltrasoundStubFromUser, CarotidUltrasoundResource, CarotidUltrasoundController>
    {
        public CarotidUltrasoundController(IUnitOfWork unitOfWork, IMapper mapper, IUrlHelper urlHelper, IErrorService errorService) : base(unitOfWork, mapper, urlHelper, errorService)
        {
        }
    }
}