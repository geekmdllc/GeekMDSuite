using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.Core.Tools.MeasurementUnits;

namespace GeekMDSuite.Analytics.Tools.Fitness
{
    public static class CalculateVo2Max
    {
        public static double FromTreadmillStressTest(TreadmillProtocol protocol, TimeDuration time, Patient patient)
        {
            return ResultByProtocol(protocol, time, patient);
        }

        public static double FromTreadmillStressTest(TreadmillExerciseStressTest stressTest, Patient patient)
        {
            return ResultByProtocol(stressTest.Protocol, stressTest.Time, patient);
        }

        private static double ResultByProtocol(TreadmillProtocol protocol, TimeDuration time, Patient patient)
        {
            switch (protocol)
            {
                case TreadmillProtocol.Bruce:
                    return Bruce(time.FractionalMinutes, patient);
                case TreadmillProtocol.BruceLowLevel:
                    throw new NotImplementedException(NotImplementedMessage(
                        TreadmillProtocol.BruceLowLevel));
                case TreadmillProtocol.Balke3Point0:
                    throw new NotImplementedException(NotImplementedMessage(
                        TreadmillProtocol.Balke3Point0));
                case TreadmillProtocol.Balke3Point4:
                    throw new NotImplementedException(NotImplementedMessage(
                        TreadmillProtocol.Balke3Point4));
                case TreadmillProtocol.Cornell:
                    throw new NotImplementedException(NotImplementedMessage(
                        TreadmillProtocol.Cornell));
                case TreadmillProtocol.Ellstad:
                    throw new NotImplementedException(NotImplementedMessage(
                        TreadmillProtocol.Ellstad));
                case TreadmillProtocol.Kattus:
                    throw new NotImplementedException(NotImplementedMessage(
                        TreadmillProtocol.Kattus));
                case TreadmillProtocol.ModifiedBruce:
                    throw new NotImplementedException(NotImplementedMessage(
                        TreadmillProtocol.ModifiedBruce));
                case TreadmillProtocol.Naughton:
                    throw new NotImplementedException(NotImplementedMessage(
                        TreadmillProtocol.Naughton));
                case TreadmillProtocol.UsAirforceSam20:
                    throw new NotImplementedException(NotImplementedMessage(
                        TreadmillProtocol.UsAirforceSam20));
                case TreadmillProtocol.UsAirforceSam33:
                    throw new NotImplementedException(NotImplementedMessage(
                        TreadmillProtocol.UsAirforceSam33));
                default:
                    throw new ArgumentOutOfRangeException(nameof(FromTreadmillStressTest) + " in " +
                                                          nameof(CalculateVo2Max) +
                                                          $" does not accept that {protocol}.");
            }
        }

        private static double Bruce(double fractionalMinutes, Patient patient)
        {
            if (Gender.IsGenotypeXx(patient.Gender))
                return 4.38 * fractionalMinutes - 3.9;
            return 14.8 - 1.379 * fractionalMinutes +
                   0.451 * Math.Pow(fractionalMinutes, 2) -
                   0.012 * Math.Pow(fractionalMinutes, 3);
        }

        private static string NotImplementedMessage(TreadmillProtocol protocol)
        {
            return nameof(FromTreadmillStressTest) + " in " + nameof(CalculateVo2Max) +
                   " does not yet implement handling of the protocol described by " + protocol + ".";
        }
    }
}