using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Classification;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyticsControllers
{
    [Produces("application/json", "application/xml")]
    public class ClassifyController : Controller
    {
        private readonly IClassificationRepository _classifications;

        public ClassifyController(IClassificationRepository classifications)
        {
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
                return BadRequest(audiogram);
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
                return BadRequest(bloodPressure);
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
                return BadRequest(bodyComposition);
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
                return BadRequest(bodyCompositionExpanded);
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
                return BadRequest(carotidUltrasound);
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
                return BadRequest(cardiovascularRegimen);
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
                return BadRequest(centralBloodPressure);
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
                return BadRequest(functionalMovementScreen);
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
                return BadRequest(gripStrengthClassificationParameters);
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
                return BadRequest(ishiharaSixPlate);
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
                return BadRequest(occularPressure);
            }
        }

        [HttpPost]
        public IActionResult PostToPeripheralVision([FromBody] PeripheralVision peripheralVision)
        {
            try
            {
                return Ok(_classifications.PeripheralVisionService.Classify(peripheralVision));
            }
            catch
            {
                return BadRequest(peripheralVision);
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
                return BadRequest(qualitativeLab);
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
                return BadRequest(quantitativeLab);
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
                return BadRequest(resistanceRegimen);
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
                return BadRequest(spirometry);
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
                return BadRequest(stretching);
            }
        }
        
        [HttpPost]
        public IActionResult PostToFitTreadmillScore([FromBody] TreadmillExerciseStressTestsClassificationParameters fitTreadmillScoreClassificationParams)
        {
            try
            {
                return Ok(_classifications.FitTreadmillScore.Classify(fitTreadmillScoreClassificationParams));
            }
            catch
            {
                return BadRequest(fitTreadmillScoreClassificationParams);
            }
        }
    }
}