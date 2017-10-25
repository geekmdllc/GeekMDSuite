using GeekMDSuite.Interpretation;

namespace GeekMDSuite.Contracts
{
    public static class FitTreadmillScore
    {

        public static FitTreadmillScoreInterpretation Interpret(double fitTreadmillScore)
        {
            return ParseTenYearMortalityRisk(Calculations.FitTreadmillScore.TenYearMortality(fitTreadmillScore));
        }

        private static FitTreadmillScoreInterpretation ParseTenYearMortalityRisk(int tenYearMortalityRisk)
        {
            switch (tenYearMortalityRisk)
            {
                case 2:
                    return FitTreadmillScoreInterpretation.LowestRisk;
                case 3:
                    return FitTreadmillScoreInterpretation.LowRisk;
                case 11:
                    return FitTreadmillScoreInterpretation.ModerateRisk;
                default:
                    return FitTreadmillScoreInterpretation.HighRisk;
            }
        }
    }
}