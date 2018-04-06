using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification;
using GeekMDSuite.WebAPI.Core.Presentation;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers
{
    [Produces("application/json", "application/xml")]
    public class ClassifyController : Controller
    {
        private readonly IClassificationRepository _classifications;
        private readonly IErrorService _errorService;

        public ClassifyController(IClassificationRepository classifications, IErrorService errorService)
        {
            _errorService = errorService;
            _classifications = classifications;
        }

        public IActionResult PostToAudiogram([FromBody] Audiogram audiogram)
        {
            try
            {
                return Ok(_classifications.Audiograms.Classify(audiogram));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("Audiogram model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the audiogram was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult PostToBloodPressure([FromBody] BloodPressure bloodPressure)
        {
            try
            {
                return Ok(_classifications.BloodPressures.Classify(bloodPressure));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("BloodPressure model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the blood pressure was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult PostToBodyComposition([FromBody] BodyCompositionClassificationParameters bodyComposition)
        {
            try
            {
                return Ok(_classifications.BodyCompositions.Classify(bodyComposition));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("BodyCompositionClassifcationParameters model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the BodyCompositionClassificationParameters model was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult PostToBodyCompositionExpanded(
            [FromBody] BodyCompositionExpandedClassificationParameters bodyCompositionExpanded)
        {
            try
            {
                return Ok(_classifications.BodyCompositionsExpanded.Classify(bodyCompositionExpanded));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("BodyCompositionExpandedClassificationParameters model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the BodyCompositionExpandedClassificationParamters was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult PostToCarotidUltrasound([FromBody] CarotidUltrasound carotidUltrasound)
        {
            try
            {
                return Ok(_classifications.CarotidUltrasounds.Classify(carotidUltrasound));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("CarotidUltrasound model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the carotid ultrasound was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult PostToCardiovascularRegimen([FromBody] CardiovascularRegimen cardiovascularRegimen)
        {
            try
            {
                return Ok(_classifications.CardiovascularRegimens.Classify(cardiovascularRegimen));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("CardiovascularRegimen model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the cardiovascular regimen was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult PostToCentralBloodPressure([FromBody] CentralBloodPressureParameters centralBloodPressure)
        {
            try
            {
                return Ok(_classifications.CentralBloodPressures.Classify(centralBloodPressure));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("CentralBloodPressureParameters model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the central blood pressure paramters was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult PostToFunctionalMovementScreen([FromBody] FunctionalMovementScreen functionalMovementScreen)
        {
            try
            {
                return Ok(_classifications.FunctionalMovements.Classify(functionalMovementScreen));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("FunctionalMovementScreen model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the functional movement screen was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult PostToGripStrength(
            [FromBody] GripStrengthClassificationParameters gripStrengthClassificationParameters)
        {
            try
            {
                return Ok(_classifications.GripStrengths.Classify(gripStrengthClassificationParameters));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("GripStrengthClassificationParamters model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the GripStrengthClassificationParameters was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult PostToIshiharaSixPlateScreen([FromBody] IshiharaSixPlate ishiharaSixPlate)
        {
            try
            {
                return Ok(_classifications.IshiharaSixPlateScreens.Classify(ishiharaSixPlate));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("IshiharaSixPlate model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the Ishihara six plate color vision screening was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult PostToOccularPressure([FromBody] OccularPressure occularPressure)
        {
            try
            {
                return Ok(_classifications.OccularPressures.Classify(occularPressure));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("OccularPresure model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the OccularPressure was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult PostToPeripheralVision([FromBody] PeripheralVision peripheralVision)
        {
            try
            {
                return Ok(_classifications.PeripheralVision.Classify(peripheralVision));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("PeripheralVisiohn model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the peripheral vision was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }
        
        [HttpPost]
        public IActionResult PostToPushups([FromBody] PushupsClassificationParameters pushups)
        {
            try
            {
                return Ok(_classifications.Pushups.Classify(pushups));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("Pushups model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the pushups was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }

        [HttpPost]
        public IActionResult PostToQualitativeLabs([FromBody] QualitativeLab qualitativeLab)
        {
            try
            {
                return Ok(_classifications.QualitativeLabs.Classify(qualitativeLab));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("QualitativeLab model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the QualitativeLab was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }
        
        [HttpPost]
        public IActionResult PostToQuantitativeLabs([FromBody] QuantitativeLabClassificationParameters quantitativeLab)
        {
            try
            {
                return Ok(_classifications.QuantitativeLabs.Classify(quantitativeLab));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("QuantitativeLab model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the QuantitativeLab was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }
        
        [HttpPost]
        public IActionResult PostToResistanceRegimen([FromBody] ResistanceRegimen resistanceRegimen)
        {
            try
            {
                return Ok(_classifications.ResistanceRegimen.Classify(resistanceRegimen));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("ResistanceRegimen model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the resistance regimen was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }
        
        [HttpPost]
        public IActionResult PostToSitAndReach([FromBody] SitAndReachClassificationParameters sitAndReach)
        {
            try
            {
                return Ok(_classifications.SitAndReach.Classify(sitAndReach));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("SitAndReach model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the SitAndReach was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }
        
        [HttpPost]
        public IActionResult PostToSitups([FromBody] SitupsClassificationParameters situps)
        {
            try
            {
                return Ok(_classifications.Situps.Classify(situps));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("Situps model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the situps was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }
        
        [HttpPost]
        public IActionResult PostToSpirometry([FromBody] SpirometryClassificationParameters spirometry)
        {
            try
            {
                return Ok(_classifications.Spirometry.Classify(spirometry));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("SpirometryClassificationParameters model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the spirometry classfication paremeters were sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }
        
        [HttpPost]
        public IActionResult PostToStretchingRegimen([FromBody] StretchingRegimen stretching)
        {
            try
            {
                return Ok(_classifications.Stretching.Classify(stretching));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("StretchingRegimen model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the StretchingRegimen was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }
        
        [HttpPost]
        public IActionResult PostToFitTreadmillScore([FromBody] TreadmillExerciseStressTestClassificationParameters fitTreadmillScoreClassificationParams)
        {
            try
            {
                return Ok(_classifications.FitTreadmillScore.Classify(fitTreadmillScoreClassificationParams));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("TreadmillExerciseStressTestClassificationParamters model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the TreadmillExerciseStressTestClassifcationParamters was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }
        
        [HttpPost]
        public IActionResult PostToVisualAcuity([FromBody] VisualAcuity visualAcuity)
        {
            try
            {
                return Ok(_classifications.VisualAcuity.Classify(visualAcuity));
            }
            catch
            {
                var error = _errorService.PayloadBuilder
                    .HasErrorCode(ErrorPayloadErrorCode.DataModelFromUserIsInvalid)
                    .HasInternalMessage("VisualAcuity model arrived incomplete or malformed.")
                    .TellsUser("Ensure that the data model for the VisualAcuity was sent properly.")
                    .Build();
                return BadRequest(error);
            }
        }
    }
}