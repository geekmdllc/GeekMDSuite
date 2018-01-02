using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Core.Tools.Fitness
{
    public static class CalculateMetabolicEquivalents
    {
        public static double FromVo2Max(double vo2Max) => vo2Max / 3.5;

        public static double FromTreadmillStressTest(ITreadmillExerciseStressTest stressTest, IPatient patient) 
            => FromVo2Max(CalculateVo2Max.FromTreadmillStressTest(stressTest, patient));
    }
}