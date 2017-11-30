namespace GeekMDSuite.Procedures
{
    public class FitTreadmillScore : IFitTreadmillScore
    {
        public FitTreadmillScore(FitTreadmillScoreParameters parameters)
        {
            _parameters = parameters;
        }
        
        public double Value => CalculateScore();
        
        public FitTreadmillScoreMortality Classification =>  ParseTenYearMortalityRisk();

        public int TenYearMortality => GetTenYearMortality();
        
        private readonly FitTreadmillScoreParameters _parameters;
        
        private FitTreadmillScoreMortality ParseTenYearMortalityRisk()
        {
            if (TenYearMortality == 2)
                return FitTreadmillScoreMortality.LowestRisk;
            if (TenYearMortality == 3)
                return FitTreadmillScoreMortality.LowRisk;
            return TenYearMortality == 11 ? FitTreadmillScoreMortality.ModerateRisk : FitTreadmillScoreMortality.HighRisk;
        }
        
        private double CalculateScore()
        {
            return _parameters.PercentMaxHeartRateReached + 12 * _parameters.MetabolicEquivalents - 4 * 
                   _parameters.AgeInYears + (Gender.IsGenotypeXx(_parameters.GenderIdentity) ? 43 : 0);
        }

        private int GetTenYearMortality()
        {
            if (Value <= -100)
                return 38;
            if (Value <= 0)
                return 11;
            return Value < 100 ? 3 : 2;
        }
    }
}