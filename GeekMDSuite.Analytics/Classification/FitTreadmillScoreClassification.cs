using System;
using GeekMDSuite.Analytics.Tools.Cardiology;
using GeekMDSuite.Analytics.Tools.Fitness;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class FitTreadmillScoreClassification : IClassifiable<FitTreadmillScoreMortality>
    {
        private readonly Patient _patient;

        private readonly TreadmillExerciseStressTest _treadmillExerciseStressTest;

        public FitTreadmillScoreClassification(TreadmillExerciseStressTestsClassificationParameters parameters)
        {
            _patient = parameters.Patient ?? throw new ArgumentNullException(nameof(parameters.Patient));
            _treadmillExerciseStressTest = parameters.TreadmillExerciseStressTest ??
                                           throw new ArgumentNullException(
                                               nameof(parameters.TreadmillExerciseStressTest));
        }

        public double Value => CalculateScore();
        public int TenYearMortality => GetTenYearMortality();
        public FitTreadmillScoreMortality Classification => ParseTenYearMortalityRisk();

        public override string ToString()
        {
            return $"Value: {Value}, Ten-Year Mortality: {TenYearMortality}%, Classification: {Classification}";
        }

        private FitTreadmillScoreMortality ParseTenYearMortalityRisk()
        {
            if (TenYearMortality == RiskPercentages.Lowest)
                return FitTreadmillScoreMortality.LowestRisk;
            if (TenYearMortality == RiskPercentages.Low)
                return FitTreadmillScoreMortality.LowRisk;
            return TenYearMortality == RiskPercentages.Moderate
                ? FitTreadmillScoreMortality.ModerateRisk
                : FitTreadmillScoreMortality.HighRisk;
        }

        private double CalculateScore()
        {
            return PercentMaxHeartRate() + 12 * MetabolicEquivalents() - 4 * _patient.Age + GenderOffset();
        }

        private int GenderOffset()
        {
            return Gender.IsGenotypeXx(_patient.Gender) ? 43 : 0;
        }

        private double MetabolicEquivalents()
        {
            return CalculateMetabolicEquivalents.FromTreadmillStressTest(_treadmillExerciseStressTest, _patient);
        }

        private int GetTenYearMortality()
        {
            if (Value < CutoffLowerLimits.ModerateRisk)
                return RiskPercentages.Highest;
            if (Value < CutoffLowerLimits.LowRisk)
                return RiskPercentages.Moderate;
            return Value < CutoffLowerLimits.LowestRisk ? RiskPercentages.Low : RiskPercentages.Lowest;
        }

        private double PercentMaxHeartRate()
        {
            return 100 * _treadmillExerciseStressTest.MaximumHeartRate / PredictMaximumHeartRate.Standard(_patient.Age);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static class RiskPercentages
        {
            public const int Lowest = 2;
            public const int Low = 3;
            public const int Moderate = 11;
            public const int Highest = 38;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static class CutoffLowerLimits
        {
            public const double LowestRisk = 100;
            public const double LowRisk = 0;
            public const double ModerateRisk = -99;
            public const double HighestRisk = double.MinValue;
        }
    }
}