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
        
        [HttpGet]
        [Route("{guid}/bodycompplus")]
        public async Task<IActionResult> GetBodyCompositionExpandeds(Guid guid)
        {
            return Ok(await _unitOfWork.BodyCompositionExpandeds.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/bodycomp")]
        public async Task<IActionResult> GetBodyCompositions(Guid guid)
        {
            return Ok(await _unitOfWork.BodyCompositions.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/cardioregimens")]
        public async Task<IActionResult> GetCardiovascularRegimens(Guid guid)
        {
            return Ok(await _unitOfWork.CardiovascularRegimens.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/carotidultrasounds")]
        public async Task<IActionResult> GetCarotidUltrasounds(Guid guid)
        {
            return Ok(await _unitOfWork.CarotidUltrasounds.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/centralbp")]
        public async Task<IActionResult> GetCentralBloodPressures(Guid guid)
        {
            return Ok(await _unitOfWork.CentralBloodPressures.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/fms")]
        public async Task<IActionResult> GetFunctionalMovementScreens(Guid guid)
        {
            return Ok(await _unitOfWork.FunctionalMovementScreens.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/gripstrength")]
        public async Task<IActionResult> GetGripStrengths(Guid guid)
        {
            return Ok(await _unitOfWork.GripStrengths.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/ishiharasix")]
        public async Task<IActionResult> GetIshiharaSixPlates(Guid guid)
        {
            return Ok(await _unitOfWork.IshiharaSixPlates.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/occularpressures")]
        public async Task<IActionResult> GetOccularPressures(Guid guid)
        {
            return Ok(await _unitOfWork.OccularPressures.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/peripheralvision")]
        public async Task<IActionResult> GetPeripheralVisions(Guid guid)
        {
            return Ok(await _unitOfWork.PeripheralVisions.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/pushups")]
        public async Task<IActionResult> GetPushups(Guid guid)
        {
            return Ok(await _unitOfWork.Pushups.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/resistanceregimens")]
        public async Task<IActionResult> GetResistanceRegimens(Guid guid)
        {
            return Ok(await _unitOfWork.ResistanceRegimens.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/sitandreaches")]
        public async Task<IActionResult> GetSitAndReaches(Guid guid)
        {
            return Ok(await _unitOfWork.SitAndReaches.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/situps")]
        public async Task<IActionResult> GetSitups(Guid guid)
        {
            return Ok(await _unitOfWork.Situps.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/spirometries")]
        public async Task<IActionResult> GetSpirometries(Guid guid)
        {
            return Ok(await _unitOfWork.Spirometries.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/stretchingregimens")]
        public async Task<IActionResult> GetStretchingRegimens(Guid guid)
        {
            return Ok(await _unitOfWork.StretchingRegimens.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/tmst")]
        public async Task<IActionResult> GetTreadmillExerciseStressTests(Guid guid)
        {
            return Ok(await _unitOfWork.TreadmillExerciseStressTests.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/visualacuities")]
        public async Task<IActionResult> GetVisualAcuites(Guid guid)
        {
            return Ok(await _unitOfWork.VisualAcuities.FindByPatient(guid));
        }
        
        [HttpGet]
        [Route("{guid}/vitalsigns")]
        public async Task<IActionResult> GetVitalSigns(Guid guid)
        {
            return Ok(await _unitOfWork.VitalSigns.FindByPatient(guid));
        }
    }
}