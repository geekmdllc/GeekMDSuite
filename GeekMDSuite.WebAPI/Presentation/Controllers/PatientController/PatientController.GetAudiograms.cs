using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.PatientController
{
    public partial class PatientController
    {
        [HttpGet]
        [Route("{guid}/audiograms")]
        public async Task<IActionResult> GetAudiograms(Guid guid)
        {
            return Ok(await _unitOfWork.Audiograms.FindByPatient(guid));
        }
    }
}