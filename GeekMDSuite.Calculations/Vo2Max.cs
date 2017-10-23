﻿using System;
using GeekMDSuite.Contracts;

namespace GeekMDSuite.Calculations
{
    public static class Vo2Max
    {
        public static double CalculateFromTreadmillExerciseStressTest(TreadmillExerciseStressTestProtocol protocol, 
            Gender gender, double minutes, double seconds)
        {
            if (minutes <= 0) throw new ArgumentOutOfRangeException(nameof(minutes));
            if (seconds <= 0) throw new ArgumentOutOfRangeException(nameof(seconds));

            double fractionalMinutes = minutes + seconds / 60;
            
            switch (protocol)
            {
                    case TreadmillExerciseStressTestProtocol.Bruce:
                        return FromBruceProtocol(gender, fractionalMinutes);
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
                    default:
                        throw new ArgumentOutOfRangeException(nameof(CalculateFromTreadmillExerciseStressTest) + " in " + 
                                                              nameof(Vo2Max) + 
                                                              " does not accept that protocol." );
            }
        }

        private static double FromBruceProtocol(Gender gender, double fractionalMinutes)
        {
            var test1 = (Math.Pow(fractionalMinutes,2));
            var test2 = (fractionalMinutes * fractionalMinutes);
            switch(gender) {
                case Gender.Female:
                case Gender.NonBinaryXx:
                    return 4.38 * fractionalMinutes - 3.9;
                default:
                    return 14.8 - 
                           (1.379 * fractionalMinutes) + 
                           (0.451 * Math.Pow(fractionalMinutes, 2)) -
                           (0.012 * Math.Pow(fractionalMinutes, 3));
            }
        }

        private static string ProtocolNotImplementedExceptionMessage(TreadmillExerciseStressTestProtocol protocol)
        {
            return nameof(CalculateFromTreadmillExerciseStressTest) + " in " + nameof(Vo2Max) + 
                   " does not yet implement handling of the protocol described by " + nameof(protocol) + ".";
        }
    }
}