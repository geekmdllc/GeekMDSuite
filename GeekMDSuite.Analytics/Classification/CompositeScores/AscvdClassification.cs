using System;
using System.Collections.Generic;
using GeekMDSuite.Analytics.Tools.Cardiology;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.Utilities.Generic;

namespace GeekMDSuite.Analytics.Classification.CompositeScores
{
    public class AscvdClassification : IClassifiable<AscvdClassificationResult>
    {
        private readonly bool _clinicialAscvdPresent;
        private readonly bool _isDiabetic;

        private readonly PooledCohortsEquation _pooledCohortsEquation;
        private readonly bool _smoker;
        private BloodPressure _bloodPressure;
        private QuantitativeLab _cholesterolHdlC;
        private QuantitativeLab _cholesterolTotal;
        private QuantitativeLab _ldlCholesterol;
        private Patient _patient;

        public AscvdClassification()
        {
        }

        public AscvdClassification(AscvdParameters ascvdParameters)
        {
            CheckForNullParameters(ascvdParameters);

            _smoker = _patient.Comorbidities.Contains(ChronicDisease.TobaccoSmoker);
            _isDiabetic = _patient.Comorbidities.Contains(ChronicDisease.Diabetes);
            _clinicialAscvdPresent = _patient.Comorbidities.Contains(ChronicDisease.DiagnosedCardiovascularDisease);
            _pooledCohortsEquation = new PooledCohortsEquation(
                PooledCohortEquationParameters.Build(_patient, _bloodPressure, _cholesterolTotal, _cholesterolHdlC));
        }

        private bool IsPossibleStatinCandidate => StatinCandidacy() == AscvdStatinCandidacy.PossibleCandidate;

        private bool IsStatinCandidate => StatinCandidacy() == AscvdStatinCandidacy.Candidate;

        private bool PatientIsInTreatmentAgeGroup => Interval<int>.Create(40, 75).ContainsClosed(_patient.Age);

        public AscvdClassificationResult Classification => Classify();

        public override string ToString()
        {
            return $"{Classify()}";
        }

        private AscvdClassificationResult Classify()
        {
            return AscvdClassificationResultBuilder.Initialize()
                .SetPooledCohortsEquation(_pooledCohortsEquation)
                .SetTenYearRiskClassification(Ascvd10YrRiskClassification())
                .SetLifetimeRiskClassification(AscvdLifetimeRiskClassification())
                .SetAspirinRecommendation(AspirinRecommendation())
                .SetStatinCandidacy(StatinCandidacy())
                .SetStatinRecommendations(StatinRecommendation())
                .SetRiskFactors(RiskFactors())
                .Build();
        }

        private AscvdRiskClassification Ascvd10YrRiskClassification()
        {
            if (_pooledCohortsEquation.Ascvd10YearRiskPercentage < 5.0) return AscvdRiskClassification.Low;
            return _pooledCohortsEquation.Ascvd10YearRiskPercentage < 7.5
                ? AscvdRiskClassification.Borderline
                : AscvdRiskClassification.Elevated;
        }

        private AscvdRiskClassification AscvdLifetimeRiskClassification()
        {
            return new AscvdLifetimeClassification(_pooledCohortsEquation.AscvdLifetimeRiskPercentage, _patient)
                .Classification;
        }

        private AscvdAspirinRecommendation AspirinRecommendation()
        {
            if (Interval<int>.Create(50, 59).ContainsClosed(_patient.Age) &&
                _pooledCohortsEquation.Ascvd10YearRiskPercentage >= 10)
                return AscvdAspirinRecommendation.Beneficial;
            if (Interval<int>.Create(60, 69).ContainsClosed(_patient.Age) &&
                _pooledCohortsEquation.Ascvd10YearRiskPercentage >= 10)
                return AscvdAspirinRecommendation.BeneficialWithReservation;
            return _pooledCohortsEquation.Ascvd10YearRiskPercentage >= 10
                ? AscvdAspirinRecommendation.InsufficientEvidenceLikelyBeneficial
                : AscvdAspirinRecommendation.InsufficientEvidenceLikelyNotBeneficial;
        }

        private AscvdStatinCandidacy StatinCandidacy()
        {
            if (_pooledCohortsEquation.Ascvd10YearRiskPercentage >= 7.5) return AscvdStatinCandidacy.Candidate;
            return _pooledCohortsEquation.Ascvd10YearRiskPercentage >= 5.0
                ? AscvdStatinCandidacy.PossibleCandidate
                : AscvdStatinCandidacy.LikelyNotCandidate;
        }

        private AscvdStatinRecommendation StatinRecommendation()
        {
            if (_clinicialAscvdPresent)
                return _patient.Age >= 75
                    ? AscvdStatinRecommendation.ModerateIntensity
                    : AscvdStatinRecommendation.HighIntensity;

            if (_isDiabetic && PatientIsInTreatmentAgeGroup)
                return IsStatinCandidate
                    ? AscvdStatinRecommendation.HighIntensity
                    : AscvdStatinRecommendation.ModerateIntensity;

            if (_ldlCholesterol.Result >= 190) return AscvdStatinRecommendation.HighIntensity;

            if (IsStatinCandidate && PatientIsInTreatmentAgeGroup)
                return AscvdStatinRecommendation.ModerateToHighIntensity;

            return IsPossibleStatinCandidate || IsStatinCandidate
                ? AscvdStatinRecommendation.PossiblyBeneficial
                : AscvdStatinRecommendation.LikelyNotBeneficial;
        }

        private List<AscvdModifiableRiskFactors> RiskFactors()
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

        private void CheckForNullParameters(AscvdParameters ascvdParameters)
        {
            _cholesterolHdlC = ascvdParameters.HdlCholesterol ??
                               throw new ArgumentNullException(nameof(ascvdParameters.HdlCholesterol));
            _cholesterolTotal = ascvdParameters.TotalCholesterol ??
                                throw new ArgumentNullException(nameof(ascvdParameters.TotalCholesterol));
            _ldlCholesterol = ascvdParameters.LdlCholesterol ??
                              throw new ArgumentNullException(nameof(ascvdParameters.LdlCholesterol));
            _bloodPressure = ascvdParameters.BloodPressure ??
                             throw new ArgumentNullException(nameof(ascvdParameters.BloodPressure));
            _patient = ascvdParameters.Patient ?? throw new ArgumentNullException(nameof(ascvdParameters.Patient));
        }
    }
}