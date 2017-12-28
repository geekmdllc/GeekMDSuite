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
        public Ascvd10YearInterpretation(IPatient patient, IBloodPressure bloodPressure, IQuantitativeLab cholesterolTotal,
            IQuantitativeLab cholesterolHdlC, IQuantitativeLab ldlCholesterol, bool hypertensiveTreatment = false, 
            bool smoker = false, bool clinicialAscvdPresent = false, bool isDiabetic = false)
        {
            _smoker = smoker;
            _cholesterolHdlC = cholesterolHdlC ?? throw new ArgumentNullException(nameof(cholesterolHdlC));
            _cholesterolTotal = cholesterolTotal ?? throw new ArgumentNullException(nameof(cholesterolTotal));
            _bloodPressure = bloodPressure ?? throw new ArgumentNullException(nameof(bloodPressure));
            _isDiabetic = isDiabetic;
            _clinicialAscvdPresent = clinicialAscvdPresent;
            _ldlCholesterol = ldlCholesterol ?? throw new ArgumentNullException(nameof(ldlCholesterol));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            _riskPercentage = new PooledCohortsEquation(_patient, _bloodPressure, _cholesterolTotal, cholesterolHdlC, hypertensiveTreatment, smoker, isDiabetic ).AscvdRiskPercentOver10Years();
        }
        
        public InterpretationText Interpretation => throw new NotImplementedException();
        public AscvdInterpretationResult Classification => Classify();

        public AscvdInterpretationResult Classify() => 
            AscvdInterpretationResult.Build(AscvdRisk(), StatinCandidacy(), StatinRecommendation(), AspirinCandidacy(), GetRiskFactors() );

        public override string ToString() => $"{Classify().ToString()}";

        private readonly double _riskPercentage;
        private readonly IPatient _patient;
        private readonly IQuantitativeLab _ldlCholesterol;
        private readonly bool _clinicialAscvdPresent;
        private readonly bool _isDiabetic;
        private readonly IBloodPressure _bloodPressure;
        private readonly IQuantitativeLab _cholesterolTotal;
        private readonly IQuantitativeLab _cholesterolHdlC;
        private bool _smoker;

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