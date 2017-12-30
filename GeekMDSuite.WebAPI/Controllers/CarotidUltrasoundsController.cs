using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Models;
using GeekMDSuite.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CarotidUltrasoundsController
    {
        public CarotidUltrasoundsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        private readonly IUnitOfWork _unitOfWork;
        
        // GET api/patients
        [HttpGet]
        public IEnumerable<CarotidUltrasoundEntity> Get()
        {
            return _unitOfWork.CarotidUltrasounds.All();
        }
    }
}
