using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.PatientController
{
    public partial class PatientController
    {
        [HttpGet]
        [Route("{guid}/bps")]
        public async Task<IActionResult> GetBloodPressures(Guid guid)
        {
            return Ok(await _unitOfWork.BloodPressures.FindByPatient(guid));
        }
    }
}