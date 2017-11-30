namespace GeekMDSuite.Procedures
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

        public GenderIdentity GenderIdentity { get; private set; }
        public double AgeInYears { get; private set; }
        public double PercentMaxHeartRateReached { get; private set; }
        public double MetabolicEquivalents { get; private set; }
    }
}