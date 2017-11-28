using GeekMDSuite.Common;

namespace GeekMDSuite.Interpretation.Fitness
{
    public static class FitTreadmillScore
    {
        public static FitTreadmillScoreInterpretation Interpret(double fitTreadmillScore)
        {
            return ParseTenYearMortalityRisk(TenYearMortality(fitTreadmillScore));
        }

        private static FitTreadmillScoreInterpretation ParseTenYearMortalityRisk(int riskPercentage)
        {
            if (riskPercentage == 2)
                return FitTreadmillScoreInterpretation.LowestRisk;
            if (riskPercentage == 3)
                return FitTreadmillScoreInterpretation.LowRisk;
            return riskPercentage == 11 ? FitTreadmillScoreInterpretation.ModerateRisk : FitTreadmillScoreInterpretation.HighRisk;
        }
        
        public static double CalculateScore(FitTreadmillScoreParameters parameters)
        {
            return parameters.PercentMaxHeartRateReached + 12 * parameters.MetabolicEquivalents - 4 * 
                   parameters.AgeInYears + (parameters.GenderIdentity == GenderIdentity.Female || parameters.GenderIdentity == GenderIdentity.NonBinaryXx ? 43 : 0);
        }

        public static int TenYearMortality(double fitTreadmillScore)
        {
            if (fitTreadmillScore <= -100) 
                return 38;
            if (fitTreadmillScore <= 0) 
                return 11;
            return fitTreadmillScore < 100 ? 3 : 2;
        }
    }
}