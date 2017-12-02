using GeekMDSuite.Tools.Cardiology;

namespace GeekMDSuite.Services.Interpretation
{
    public class FitTreadmillScoreParameters
    {
        public FitTreadmillScoreParameters(GenderIdentity gender, 
            double ageInYears, 
            double maxHeartRateAchieved, 
            double metabolicEquivalents)
        {
            GenderIdentity = gender;
            AgeInYears = ageInYears;
            PercentMaxHeartRateAchieved = CalculatePercentMaxHeartRate(maxHeartRateAchieved);
            MetabolicEquivalents = metabolicEquivalents;
        }

        private double CalculatePercentMaxHeartRate( double maxHeartRateReached)
        {
             return 100 * maxHeartRateReached / PredictMaximumHeartRate.Standard(AgeInYears);
        }

        public GenderIdentity GenderIdentity { get; }
        public double AgeInYears { get; }
        public double PercentMaxHeartRateAchieved { get; }
        public double MetabolicEquivalents { get; }
    }
}