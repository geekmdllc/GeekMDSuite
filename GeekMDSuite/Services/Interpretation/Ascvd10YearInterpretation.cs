using System;
using System.Collections.Generic;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.Tools.Cardiology;
using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Services.Interpretation
{
    // https://www.uspreventiveservicestaskforce.org/Page/Document/UpdateSummaryFinal/aspirin-to-prevent-cardiovascular-disease-and-cancer
    // Assumes 10+ yr longevity, no bleeding risk, no prior heart attack or stroke
    // 2013 ACC/AHA
    public class Ascvd10YearInterpretation : IInterpretable<AscvdInterpretationResult>
    {
        public Ascvd10YearInterpretation(IPooledCohortEquationParameters equationParams, IQuantitativeLab ldlCholesterol, bool clinicialAscvdPresent = false)
        {
            _smoker = equationParams.Smoker;
            _cholesterolHdlC = equationParams.HdlCholesterol ?? throw new ArgumentNullException(nameof(equationParams.HdlCholesterol));
            _cholesterolTotal = equationParams.TotalCholesterol ?? throw new ArgumentNullException(nameof(equationParams.TotalCholesterol));
            _bloodPressure = equationParams.BloodPressure ?? throw new ArgumentNullException(nameof(equationParams.BloodPressure));
            _isDiabetic = equationParams.Diabetic;
            _clinicialAscvdPresent = clinicialAscvdPresent;
            _ldlCholesterol = ldlCholesterol ?? throw new ArgumentNullException(nameof(ldlCholesterol));
            _patient = equationParams.Patient ?? throw new ArgumentNullException(nameof(equationParams.Patient));
            _riskPercentage = PooledCohortsEquation.Initialize(equationParams).Ascvd10YearRiskPercentage;
        }
        
        public InterpretationText Interpretation => throw new NotImplementedException();
        public AscvdInterpretationResult Classification => Classify();

        public AscvdInterpretationResult Classify() => 
            AscvdInterpretationResult.Build(AscvdRisk(), StatinCandidacy(), StatinRecommendation(), AspirinCandidacy(), GetRiskFactors() );

        public override string ToString() => $"{Classify()}";

        private readonly double _riskPercentage;
        private readonly IPatient _patient;
        private readonly IQuantitativeLab _ldlCholesterol;
        private readonly bool _clinicialAscvdPresent;
        private readonly bool _isDiabetic;
        private readonly IBloodPressure _bloodPressure;
        private readonly IQuantitativeLab _cholesterolTotal;
        private readonly IQuantitativeLab _cholesterolHdlC;
        private readonly bool _smoker;

        private AscvdRiskClassification AscvdRisk()
        {
            if (_riskPercentage < 5.0) return AscvdRiskClassification.Low;
            return _riskPercentage < 7.5 ? AscvdRiskClassification.Borderline 
                : AscvdRiskClassification.Elevated;
        }

        private AscvdAspirinRecommendation AspirinCandidacy()
        {
            if (Interval<int>.Create(50, 59).ContainsClosed(_patient.Age) && _riskPercentage >= 10)
                return AscvdAspirinRecommendation.Beneficial;
            if (Interval<int>.Create(60, 60).ContainsClosed(_patient.Age) && _riskPercentage >= 10)
                return AscvdAspirinRecommendation.BeneficialWithReservation;
            return _riskPercentage >= 10 ? AscvdAspirinRecommendation.InsufficientEvidenceLikelyBeneficial 
                : AscvdAspirinRecommendation.InsufficientEvidenceLikelyNotBeneficial;
        }

        private AscvdStatinCandidacy StatinCandidacy()
        {
            if (_riskPercentage >= 7.5) return AscvdStatinCandidacy.Candidate;
            return _riskPercentage >= 5.0 ? AscvdStatinCandidacy.PossibleCandidate 
                : AscvdStatinCandidacy.LikelyNotCandidate;
        }

        private AscvdStatinRecommendation StatinRecommendation()
        {
            if (_clinicialAscvdPresent)
                return _patient.Age >= 75 ? AscvdStatinRecommendation.ModerateIntensity : AscvdStatinRecommendation.HighIntensity;

            if (_isDiabetic && PatientIsInTreatmentAgeGroup)
                return IsStatinCandidate ? AscvdStatinRecommendation.HighIntensity  : AscvdStatinRecommendation.ModerateIntensity;

            if (_ldlCholesterol.Result >= 190) return AscvdStatinRecommendation.HighIntensity;
            
            if (IsStatinCandidate && PatientIsInTreatmentAgeGroup)
                return AscvdStatinRecommendation.ModerateToHighIntensity;

            return StatinCandidacy() == AscvdStatinCandidacy.PossibleCandidate 
                ? AscvdStatinRecommendation.PossiblyBeneficial 
                : AscvdStatinRecommendation.LikelyNotBeneficial;
        }

        private bool IsStatinCandidate => StatinCandidacy() == AscvdStatinCandidacy.Candidate;

        private bool PatientIsInTreatmentAgeGroup => Interval<int>.Create(40,75).ContainsClosed(_patient.Age);
        
        private List<AscvdModifiableRiskFactors> GetRiskFactors()
        {
            var riskFactors = new List<AscvdModifiableRiskFactors>();
            
            if (_isDiabetic) riskFactors.Add(AscvdModifiableRiskFactors.Diabetes);
            if (_clinicialAscvdPresent) riskFactors.Add(AscvdModifiableRiskFactors.ExistingCardiovascularDisease);
            if (_ldlCholesterol.Result >= 190) riskFactors.Add(AscvdModifiableRiskFactors.LdlCholesterolElevated);
            if (_bloodPressure.Systolic >= 120) riskFactors.Add(AscvdModifiableRiskFactors.BloodPressureElevated);
            if (_cholesterolHdlC.Result < 40) riskFactors.Add(AscvdModifiableRiskFactors.HdLCholesterolLow);
            if (_cholesterolTotal.Result >= 180) riskFactors.Add(AscvdModifiableRiskFactors.TotalCholesterolElevated);
            if (_smoker) riskFactors.Add(AscvdModifiableRiskFactors.Smoker);

            return riskFactors;
        }
    }
}