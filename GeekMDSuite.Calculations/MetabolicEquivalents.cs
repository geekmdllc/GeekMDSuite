using GeekMDSuite.Common;

namespace GeekMDSuite.Calculations
{
    public static class MetabolicEquivalents
    {
        public static double Calculate(double vo2Max)
        {
            return vo2Max / 3.5;
        }
        
        public static double Calculate(
            TreadmillProtocol protocol,
            GenderIdentity gender, 
            TimeDuration timeDuration)
        {
            return Calculate(
                Vo2Max.Calculate(protocol, timeDuration, gender));
        }
    }
}