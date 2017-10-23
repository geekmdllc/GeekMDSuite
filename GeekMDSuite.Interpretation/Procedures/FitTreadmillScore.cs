namespace GeekMDSuite.Interpretation.Procedures
{
    public static class FitTreadmillScore
    {

        public static FitTreadmillScoreInterpretation Interpret(double fitTreadmillScore)
        {
            var tenYearMortalityRisk = Calculations.FitTreadmillScore.TenYearMortality(fitTreadmillScore);

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