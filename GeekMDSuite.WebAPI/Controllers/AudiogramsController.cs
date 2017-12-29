using System.Collections.Generic;
using GeekMDSuite.WebAPI.Models;
using GeekMDSuite.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AudiogramsController : Controller
    {
        public AudiogramsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        // GET api/audiograms
        [HttpGet]
        public IEnumerable<AudiogramEntity> Get()
        {
           return _unitOfWork.Audiograms.All();
        }
        
        // POST api/audiograms/
        [HttpPost]
        public void Post([FromBody] AudiogramEntity audiogram)
        {
            _unitOfWork.Audiograms.Add(audiogram);
            _unitOfWork.Complete();
        }
        
        private readonly IUnitOfWork _unitOfWork;
    }
}