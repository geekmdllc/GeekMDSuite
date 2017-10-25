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
            if (tenYearMortalityRisk == 2)
                return FitTreadmillScoreInterpretation.LowestRisk;
            if (tenYearMortalityRisk == 3)
                return FitTreadmillScoreInterpretation.LowRisk;
            return tenYearMortalityRisk == 11 ? FitTreadmillScoreInterpretation.ModerateRisk : FitTreadmillScoreInterpretation.HighRisk;
        }
    }
}