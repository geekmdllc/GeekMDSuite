using System;
using GeekMDSuite.Common;

namespace GeekMDSuite.Calculations
{
    public static class Vo2Max
    {
        public static double Calculate(TreadmillProtocol protocol, TimeDuration time, GenderIdentity gender)
        {
            return ProtocolSpecificCalculation(gender, protocol, time);
        }

        private static double ProtocolSpecificCalculation(GenderIdentity genders, TreadmillProtocol protocol,
            TimeDuration timeDuration)
        {
            switch (protocol)
            {
                case TreadmillProtocol.Bruce:
                    return Bruce(genders, timeDuration.FractionalMinutes);
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
                    throw new ArgumentOutOfRangeException(nameof(Calculate) + " in " +
                                                          nameof(Vo2Max) +
                                                          " does not accept that protocol.");
            }
        }

        

        private static double Bruce(GenderIdentity gender, double fractionalMinutes)
        {
            if (Gender.IsGenotypeXx(gender))
                return 4.38 * fractionalMinutes - 3.9; 
            return 14.8 - (1.379 * fractionalMinutes) +
                       (0.451 * Math.Pow(fractionalMinutes, 2)) -
                       (0.012 * Math.Pow(fractionalMinutes, 3));
        }

        private static string NotImplementedMessage(TreadmillProtocol protocol)
        {
            return nameof(Calculate) + " in " + nameof(Vo2Max) + 
                   " does not yet implement handling of the protocol described by " + protocol + ".";
        }
    }
}