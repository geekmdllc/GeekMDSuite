using GeekMDSuite.Contracts;

namespace GeekMDSuite.Calculations
{
    public static class MetabolicEquivalents
    {
        public static double CalculateFromVo2Max(double vo2Max)
        {
            return vo2Max / 3.5;
        }
        
        public static double CalculateFromTreadmillExerciseStressTest(
            TreadmillExerciseStressTestProtocol protocol,
            Gender gender, 
            double minutes, 
            double seconds)
        {
            return CalculateFromVo2Max(
                Vo2Max.CalculateFromTreadmillExerciseStressTest(
                    protocol, 
                    gender, 
                    minutes,
                    seconds));
        }
    }
}