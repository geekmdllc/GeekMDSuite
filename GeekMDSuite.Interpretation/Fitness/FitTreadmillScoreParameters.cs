using GeekMDSuite;

namespace GeekMDSuite.Interpretation.Fitness
{
    public class FitTreadmillScoreParameters
    {
        public FitTreadmillScoreParameters(GenderIdentity genders, double ageInYears, double percentMaxHeartRateReached, double metabolicEquivalents)
        {
            GenderIdentity = genders;
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