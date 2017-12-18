using GeekMDSuite.Procedures;

namespace GeekMDSuite.Tools.Fitness
{
    public static class CalculateMetabolicEquivalents
    {
        public static double FromVo2Max(Vo2Max vo2Max)
        {
            return vo2Max.Value / 3.5;
        }
        
        public static double FromTreadmillStressTest(ITreadmillExerciseStressTest stressTest, IPatient patient)
        {
            return FromVo2Max(CalculateVo2Max.FromTreadmillStressTest(stressTest, patient));
        }
    }
}