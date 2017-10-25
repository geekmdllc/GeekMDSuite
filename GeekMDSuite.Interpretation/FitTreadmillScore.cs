using GeekMDSuite.Interpretation;

namespace GeekMDSuite.Contracts
{
    public static class FitTreadmillScore
    {

        public static FitTreadmillScoreInterpretation Interpret(double fitTreadmillScore)
        {
            return ParseTenYearMortalityRisk(Calculations.FitTreadmillScore.TenYearMortality(fitTreadmillScore));
        }

        private static FitTreadmillScoreInterpretation ParseTenYearMortalityRisk(int riskPercentage)
        {
            if (riskPercentage == 2)
                return FitTreadmillScoreInterpretation.LowestRisk;
            if (riskPercentage == 3)
                return FitTreadmillScoreInterpretation.LowRisk;
            return riskPercentage == 11 ? FitTreadmillScoreInterpretation.ModerateRisk : FitTreadmillScoreInterpretation.HighRisk;
        }
    }
}