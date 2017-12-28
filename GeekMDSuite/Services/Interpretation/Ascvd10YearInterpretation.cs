using System;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Services.Interpretation
{
    // https://www.uspreventiveservicestaskforce.org/Page/Document/UpdateSummaryFinal/aspirin-to-prevent-cardiovascular-disease-and-cancer
    // Assumes 10+ yr longevity, no bleeding risk, no prior heart attack or stroke
    // 2013 ACC/AHA
    public class Ascvd10YearInterpretation : IInterpretable<AscvdInterpretationResult>
    {
        public Ascvd10YearInterpretation(IPatient patient,
            IQuantitativeLab ldlCholesterol, double riskPercentage, bool clinicialAscvdPresent = false,
            bool isDiabetic = false)
        {
            _isDiabetic = isDiabetic;
            _clinicialAscvdPresent = clinicialAscvdPresent;
            _ldlCholesterol = ldlCholesterol ?? throw new ArgumentNullException(nameof(ldlCholesterol));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            _riskPercentage = riskPercentage;
        }
        
        public InterpretationText Interpretation => throw new NotImplementedException();
        public AscvdInterpretationResult Classification => Classify();

        public AscvdInterpretationResult Classify() => 
            AscvdInterpretationResult.Build(AscvdRisk(), StatinCandidacy(), StatinRecommendation(), AspirinCandidacy() );

        private readonly double _riskPercentage;
        private readonly IPatient _patient;
        private readonly IQuantitativeLab _ldlCholesterol;
        private readonly bool _clinicialAscvdPresent;
        private readonly bool _isDiabetic;

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
    }
}