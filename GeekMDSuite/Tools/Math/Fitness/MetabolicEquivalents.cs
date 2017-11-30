using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Tools.Math.Fitness
{
    public static class MetabolicEquivalents
    {
        public static double FromVo2Max(double vo2Max)
        {
            return vo2Max / 3.5;
        }
        
        public static double FromTreadmillStressTest(TreadmillProtocol protocol, TimeDuration timeDuration, Gender gender)
        {
            return FromVo2Max(Vo2Max.FromTreadmillStressTest(protocol, timeDuration, gender.Category));
        }
    }
}