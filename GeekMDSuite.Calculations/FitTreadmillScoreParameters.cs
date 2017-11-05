using GeekMDSuite.Common;

namespace GeekMDSuite.Calculations
{
    public class FitTreadmillScoreParameters
    {
        public FitTreadmillScoreParameters(Genders genders, double ageInYears, double percentMaxHeartRateReached, double metabolicEquivalents)
        {
            Genders = genders;
            AgeInYears = ageInYears;
            PercentMaxHeartRateReached = percentMaxHeartRateReached;
            MetabolicEquivalents = metabolicEquivalents;
        }

        public Genders Genders { get; private set; }
        public double AgeInYears { get; private set; }
        public double PercentMaxHeartRateReached { get; private set; }
        public double MetabolicEquivalents { get; private set; }
    }
}