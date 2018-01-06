﻿using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BodyCompositionsController : AnalyzablePatientDataController<BodyCompositionEntity>
    {
        private readonly IClassificationRepository _classifications;

        public BodyCompositionsController(IUnitOfWork unitOfWork, IClassificationRepository classifications) :
            base(unitOfWork)
        {
            _classifications = classifications;
        }

        public override IActionResult Interpret(int id)
        {
            throw new NotImplementedException();
        }

        public override IActionResult Classify(int id)
        {
            try
            {
                return Ok(_classifications.BodyCompositions.InitializeWith(id));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}