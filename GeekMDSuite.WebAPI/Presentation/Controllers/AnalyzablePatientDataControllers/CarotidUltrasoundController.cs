using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    [Produces("application/json", "application/xml")]
    public class CarotidUltrasoundController : VisitDataController<CarotidUltrasoundEntity>
    {

        public CarotidUltrasoundController(IUnitOfWork unitOfWork) :
            base(unitOfWork)
        {

        }
    }
}