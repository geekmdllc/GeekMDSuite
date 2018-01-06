using System;
using System.Collections.Generic;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class SpirometryClassification : IClassifiable<SpirometryClassificationResult>
    {
        private readonly BodyComposition _bodyComposition;
        private readonly Patient _patient;

        private readonly Spirometry _spirometry;

        public SpirometryClassification(Spirometry spirometry, Patient patient, BodyComposition bodyComposition)
        {
            _spirometry = spirometry ?? throw new ArgumentNullException(nameof(spirometry));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            _bodyComposition = bodyComposition ?? throw new ArgumentNullException(nameof(bodyComposition));
        }

        public double PredictedForcedExpiratoryVolume1Second => Gender.IsGenotypeXy(_patient.Gender)
            ? GetPredictedMaleForcedExpriatoryVolume1Second()
            : GetPredictedFemaleForcedExpiratoryVolume1Second();

        public double PredictedForcedVitalCapacity => Gender.IsGenotypeXy(_patient.Gender)
            ? PredictMaleForcedVitalCapacity()
            : PredictFemaleForcedVitalCapacity();

        public double PredictedForcedExpiratoryVolumeToForcedVitalCapacityRatio =>
            Gender.IsGenotypeXy(_patient.Gender)
                ? PredictMaleForcedExpiratoryVolumeToForcedVitalCapacityRatio()
                : PredictFemaleForcedExpiratoryVolumeToForcedVitalCapacityRatio();

        private static Dictionary<Race, double> RaceFactor => new Dictionary<Race, double>
        {
            {Race.White, 1.0},
            {Race.AmericanIndianOrAlaskaNative, 0.93},
            {Race.Asian, 0.93},
            {Race.Latin, 0.93},
            {Race.NativeHawaiianOrOtherPacificIslander, 0.93},
            {Race.BlackOrAfricanAmerican, 0.87}
        };

        public SpirometryClassificationResult Classification => ClassifySpirometryResults();

        public override string ToString()
        {
            return $"FVC: {_spirometry.ForcedVitalCapacity} L, " +
                   $"FEV1:FVC: {_spirometry.ForcedExpiratoryVolume1SecondToForcedVitalCapacityRatio}, " +
                   $"Classification: {Classification.ToString()}";
        }

        private SpirometryClassificationResult ClassifySpirometryResults()
        {
            var obstructivePattern = _spirometry.ForcedExpiratoryVolume1SecondToForcedVitalCapacityRatio < 0.7;
            var preservedVitalCapacity = _spirometry.ForcedVitalCapacity / PredictedForcedVitalCapacity >= 0.8;

            if (obstructivePattern)
                return preservedVitalCapacity
                    ? GradeObstructionSeverity()
                    : SpirometryClassificationResult.MixedPattern;

            return preservedVitalCapacity ? SpirometryClassificationResult.Normal : GradeRestrictionSeverity();
        }

        private double PredictFemaleForcedVitalCapacity()
        {
            return RaceFactor[_patient.Race] *
                   (0.0443 * _bodyComposition.Height.Centimeters - 0.026 * _patient.Age - 2.89);
        }

        private double PredictMaleForcedVitalCapacity()
        {
            return RaceFactor[_patient.Race] *
                   (0.0576 * _bodyComposition.Height.Centimeters - 0.0269 * _patient.Age - 4.34);
        }

        private double GetPredictedFemaleForcedExpiratoryVolume1Second()
        {
            return RaceFactor[_patient.Race] *
                   (0.0394 * _bodyComposition.Height.Centimeters - 0.025 * _patient.Age - 2.6);
        }

        private double GetPredictedMaleForcedExpriatoryVolume1Second()
        {
            return RaceFactor[_patient.Race] *
                   (0.043 * _bodyComposition.Height.Centimeters - 0.029 * _patient.Age - 2.49);
        }

        private double PredictFemaleForcedExpiratoryVolumeToForcedVitalCapacityRatio()
        {
            return 89.1 - 0.19 * _patient.Age;
        }

        private double PredictMaleForcedExpiratoryVolumeToForcedVitalCapacityRatio()
        {
            return 87.2 - 0.18 * _patient.Age;
        }

        private bool Fev1LessThanGivenPercent(double val)
        {
            var fractionOfPredicted = PredictedForcedExpiratoryVolume1Second * val / 100.0;
            var test = _spirometry.ForcedExpiratoryVolume1Second < fractionOfPredicted;
            return test;
        }

        private SpirometryClassificationResult GradeRestrictionSeverity()
        {
            if (Fev1LessThanGivenPercent(35))
                return SpirometryClassificationResult.RestrictionVerySevere;

            if (Fev1LessThanGivenPercent(50))
                return SpirometryClassificationResult.RestrictionSevere;

            if (Fev1LessThanGivenPercent(60))
                return SpirometryClassificationResult.RestrictionModeratelySevere;

            return Fev1LessThanGivenPercent(70)
                ? SpirometryClassificationResult.RestrictionModerate
                : SpirometryClassificationResult.RestrictionMild;
        }

        private SpirometryClassificationResult GradeObstructionSeverity()
        {
            if (Fev1LessThanGivenPercent(35))
                return SpirometryClassificationResult.ObstructionVerySevere;

            if (Fev1LessThanGivenPercent(50))
                return SpirometryClassificationResult.ObstructionSevere;

            if (Fev1LessThanGivenPercent(60))
                return SpirometryClassificationResult.ObstructionModeratelySevere;

            return Fev1LessThanGivenPercent(70)
                ? SpirometryClassificationResult.ObstructionModerate
                : SpirometryClassificationResult.ObstructionMild;
        }
    }

    // Predicted value source medcalc3000
    /*
     References
    
        Quanjer PhH, Tammeling GJ, Cotes JE, et. al. Lung volume and forced ventilatory flows. Report Working Party Standardization of lung function tests. Official Statement European Respiratory Society. Eur Respir J. 1993; 6 Suppl 16: 5-40. PubMed Logo
        Falaschetti E, Laiho J, Primatesta P, Purdon S. Prediction equations for normal and low lung function from the Health Survey for England. Eur Respir J. 2004 Mar;23(3):456-63. PubMed Logo
        Internet Site: Become an Expert in Spirometry Website, http://www.spirxpert.com/
    
        FEV1 = Race * ((0.0395 * Height) - (0.025 * Age) - 2.6 )
        FVC = Race * ((0.0443 * Height) - (0.026 * Age) - 2.89 )
        FEV1FVCRatio = 89.1 - (0.19 * Age)
        
        Caucasian 1.0
        Black 0.87
        Asian 0.93
    */
}