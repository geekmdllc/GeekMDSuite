using GeekMDSuite.Tools.Fitness;
using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite
{
    public static class MetabolicEquivalents
    {
        public static double FromVo2Max(Vo2Max vo2Max)
        {
            return vo2Max.Value / 3.5;
        }
        
        public static double FromTreadmillStressTest(TreadmillExerciseStressTest stressTest, IPatient patient)
        {
            return FromVo2Max(CalculateVo2Max.FromTreadmillStressTest(stressTest.Protocol, stressTest.Time, patient));
        }
    }
}