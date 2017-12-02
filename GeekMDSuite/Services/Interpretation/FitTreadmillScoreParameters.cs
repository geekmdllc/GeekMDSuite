namespace GeekMDSuite.Services.Interpretation
{
    public class FitTreadmillScoreParameters
    {
        public FitTreadmillScoreParameters(GenderIdentity gender, 
            double ageInYears, 
            double percentMaxHeartRateReached, 
            double metabolicEquivalents)
        {
            GenderIdentity = gender;
            AgeInYears = ageInYears;
            PercentMaxHeartRateReached = percentMaxHeartRateReached;
            MetabolicEquivalents = metabolicEquivalents;
        }

        public GenderIdentity GenderIdentity { get; }
        public double AgeInYears { get; }
        public double PercentMaxHeartRateReached { get; }
        public double MetabolicEquivalents { get; }
    }
}