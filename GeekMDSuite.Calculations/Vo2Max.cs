using System;
using GeekMDSuite.Contracts;

namespace GeekMDSuite.Calculations
{
    public static class Vo2Max
    {
        public static double CalculateFromTreadmillExerciseStressTest(Gender gender,
            TreadmillExerciseStressTestProtocol protocol, TimeDuration timeDuration)
        {
            return GetProtocolSpecificResult(gender, protocol, timeDuration);
        }

        private static double GetProtocolSpecificResult(Gender gender, TreadmillExerciseStressTestProtocol protocol,
            TimeDuration timeDuration)
        {
            switch (protocol)
            {
                case TreadmillExerciseStressTestProtocol.Bruce:
                    return CalculateFromBruceProtocol(gender, timeDuration.FractionalMinutes);
                case TreadmillExerciseStressTestProtocol.BruceLowLevel:
                    throw new NotImplementedException(ProtocolNotImplementedExceptionMessage(
                        TreadmillExerciseStressTestProtocol.BruceLowLevel));
                case TreadmillExerciseStressTestProtocol.Balke3Point0:
                    throw new NotImplementedException(ProtocolNotImplementedExceptionMessage(
                        TreadmillExerciseStressTestProtocol.Balke3Point0));
                case TreadmillExerciseStressTestProtocol.Balke3Point4:
                    throw new NotImplementedException(ProtocolNotImplementedExceptionMessage(
                        TreadmillExerciseStressTestProtocol.Balke3Point4));
                case TreadmillExerciseStressTestProtocol.Cornell:
                    throw new NotImplementedException(ProtocolNotImplementedExceptionMessage(
                        TreadmillExerciseStressTestProtocol.Cornell));
                case TreadmillExerciseStressTestProtocol.Ellstad:
                    throw new NotImplementedException(ProtocolNotImplementedExceptionMessage(
                        TreadmillExerciseStressTestProtocol.Ellstad));
                case TreadmillExerciseStressTestProtocol.Kattus:
                    throw new NotImplementedException(ProtocolNotImplementedExceptionMessage(
                        TreadmillExerciseStressTestProtocol.Kattus));
                case TreadmillExerciseStressTestProtocol.ModifiedBruce:
                    throw new NotImplementedException(ProtocolNotImplementedExceptionMessage(
                        TreadmillExerciseStressTestProtocol.ModifiedBruce));
                case TreadmillExerciseStressTestProtocol.Naughton:
                    throw new NotImplementedException(ProtocolNotImplementedExceptionMessage(
                        TreadmillExerciseStressTestProtocol.Naughton));
                case TreadmillExerciseStressTestProtocol.UsAirforceSam20:
                    throw new NotImplementedException(ProtocolNotImplementedExceptionMessage(
                        TreadmillExerciseStressTestProtocol.UsAirforceSam20));
                case TreadmillExerciseStressTestProtocol.UsAirforceSam33:
                    throw new NotImplementedException(ProtocolNotImplementedExceptionMessage(
                        TreadmillExerciseStressTestProtocol.UsAirforceSam33));
                default:
                    throw new ArgumentOutOfRangeException(nameof(CalculateFromTreadmillExerciseStressTest) + " in " +
                                                          nameof(Vo2Max) +
                                                          " does not accept that protocol.");
            }
        }

        

        private static double CalculateFromBruceProtocol(Gender gender, double fractionalMinutes)
        {
            if (gender == Gender.Female || gender == Gender.NonBinaryXx)
                return 4.38 * fractionalMinutes - 3.9; 
            return 14.8 - (1.379 * fractionalMinutes) +
                       (0.451 * Math.Pow(fractionalMinutes, 2)) -
                       (0.012 * Math.Pow(fractionalMinutes, 3));
        }

        private static string ProtocolNotImplementedExceptionMessage(TreadmillExerciseStressTestProtocol protocol)
        {
            return nameof(CalculateFromTreadmillExerciseStressTest) + " in " + nameof(Vo2Max) + 
                   " does not yet implement handling of the protocol described by " + protocol + ".";
        }
    }
}