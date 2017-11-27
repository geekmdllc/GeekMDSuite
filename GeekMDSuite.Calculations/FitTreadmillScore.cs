
using GeekMDSuite.Common;

namespace GeekMDSuite.Calculations
{
    public static class FitTreadmillScore
    {
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