using GeekMDSuite.Common;

namespace GeekMDSuite.Calculations
{
    public class FitTreadmillScoreParameters
    {
        public FitTreadmillScoreParameters(Gender gender, double ageInYears, double percentMaxHeartRateReached, double metabolicEquivalents)
        {
            Gender = gender;
            AgeInYears = ageInYears;
            PercentMaxHeartRateReached = percentMaxHeartRateReached;
            MetabolicEquivalents = metabolicEquivalents;
        }

        public Gender Gender { get; private set; }
        public double AgeInYears { get; private set; }
        public double PercentMaxHeartRateReached { get; private set; }
        public double MetabolicEquivalents { get; private set; }
    }
}