using FitInterp = GeekMDSuite.Interpretation.Fitness.FitTreadmillScoreInterpretation;

namespace GeekMDSuite.Interpretation.Fitness
{
    public static class FitTreadmillScore
    {
        public static FitInterp Interpret(double fitTreadmillScore)
        {
            return ParseTenYearMortalityRisk(Calculations.FitTreadmillScore.TenYearMortality(fitTreadmillScore));
        }

        private static FitInterp ParseTenYearMortalityRisk(int riskPercentage)
        {
            if (riskPercentage == 2)
                return FitInterp.LowestRisk;
            if (riskPercentage == 3)
                return FitInterp.LowRisk;
            return riskPercentage == 11 ? FitInterp.ModerateRisk : FitInterp.HighRisk;
        }
    }
}