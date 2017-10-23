using GeekMDSuite.Contracts;
using GeekMDSuite.Contracts.Procedures;

namespace GeekMDSuite.Calculations.MetabolicEquivalents
{
    public static class FromVo2Max
    {
        public static double Calculate(double vo2Max)
        {
            return vo2Max / 3.5;
        }
    }

    public static class FromTreadmillExerciseStressTest
    {
        public static double Calculate(
            TreadmillExerciseStressTestProtocol protocol,
            Gender gender, 
            double minutes, 
            double seconds)
        {
            return FromVo2Max.Calculate(
                VO2Max.FromTreadmillExerciseStressTest.Calculate(
                    protocol, 
                    gender, 
                    minutes,
                    seconds));
        }
    }
}