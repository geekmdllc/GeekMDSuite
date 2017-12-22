using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Tools;
using GeekMDSuite.Tools.Cardiology;
using GeekMDSuite.Tools.Fitness;

namespace GeekMDSuite.Services.Interpretation
{
    public class FitTreadmillScoreInterpretation : IInterpretable<FitTreadmillScoreMortality>
    {
        public FitTreadmillScoreInterpretation(ITreadmillExerciseStressTest treadmillExerciseStressTest,
            IPatient patient)
        {
            _patient = patient;
            _treadmillExerciseStressTest = treadmillExerciseStressTest;
        }

        public InterpretationText Interpretation => throw new NotImplementedException();
        public double Value => CalculateScore();
        public FitTreadmillScoreMortality Classification =>  ParseTenYearMortalityRisk();
        public int TenYearMortality => GetTenYearMortality();

        private readonly ITreadmillExerciseStressTest _treadmillExerciseStressTest;
        private readonly IPatient _patient;
        
        public static class RiskPercentages
        {
            public static readonly int Lowest = 2;
            public static readonly int Low = 3;
            public static readonly int Moderate = 11;
            public static readonly int Highest = 38;
        }
        
        public static class CutoffLowerLimits
        {
            public static readonly double LowestRisk = 100;
            public static readonly double LowRisk = 0;
            public static readonly double ModerateRisk = -99;
            public static readonly double HighestRisk = double.MinValue;
        }

        public override string ToString() => 
            $"Value: {Value}, Ten-Year Mortality: {TenYearMortality}%, Classification: {Classification}";

        private FitTreadmillScoreMortality ParseTenYearMortalityRisk()
        {
            if (TenYearMortality == RiskPercentages.Lowest)
                return FitTreadmillScoreMortality.LowestRisk;
            if (TenYearMortality == RiskPercentages.Low)
                return FitTreadmillScoreMortality.LowRisk;
            return TenYearMortality == RiskPercentages.Moderate 
                ? FitTreadmillScoreMortality.ModerateRisk : FitTreadmillScoreMortality.HighRisk;
        }
        
        private double CalculateScore() => 
            PercentMaxHeartRate() +  12 * MetabolicEquivalents() - 4 *  _patient.Age + GenderOffset();

        private int GenderOffset() => (Gender.IsGenotypeXx(_patient.Gender) ? 43 : 0);

        private double MetabolicEquivalents() => 
            CalculateMetabolicEquivalents.FromTreadmillStressTest(_treadmillExerciseStressTest, _patient);

        private int GetTenYearMortality()
        {
            if (Value < CutoffLowerLimits.ModerateRisk)
                return RiskPercentages.Highest;
            if (Value < CutoffLowerLimits.LowRisk)
                return RiskPercentages.Moderate;
            return Value < CutoffLowerLimits.LowestRisk ? RiskPercentages.Low : RiskPercentages.Lowest;
        }
        
        private double PercentMaxHeartRate() 
            => 100 * _treadmillExerciseStressTest.MaximumHeartRate / PredictMaximumHeartRate.Standard(_patient.Age);
    }
}