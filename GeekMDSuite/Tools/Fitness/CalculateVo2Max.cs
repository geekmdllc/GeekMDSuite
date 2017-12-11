using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.Services.Interpretation;
using GeekMDSuite.Tools.MeasurementUnits;
using FitnessClassification = GeekMDSuite.Services.Interpretation.FitnessClassification;

namespace GeekMDSuite.Tools.Fitness
{
    public static class CalculateVo2Max
    {
        public static Vo2Max FromTreadmillStressTest(TreadmillProtocol protocol, ITimeDuration time, IPatient patient)
        {
            var value = ResultByProtocol(protocol, time, patient);
            var classification = Classify(value, patient);
            return new Vo2Max(value, classification);
        }

        private static double ResultByProtocol(TreadmillProtocol protocol, ITimeDuration time, IPatient patient)
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
                                                          nameof(CalculateVo2Max) + $" does not accept that {protocol}.");
            }
        }

        private static double Bruce(double fractionalMinutes, IPatient patient)
        {
            if (Gender.IsGenotypeXx(patient.Gender))
                return 4.38 * fractionalMinutes - 3.9; 
            return 14.8 - (1.379 * fractionalMinutes) +
                       (0.451 * System.Math.Pow(fractionalMinutes, 2)) -
                       (0.012 * System.Math.Pow(fractionalMinutes, 3));
        }

        private static string NotImplementedMessage(TreadmillProtocol protocol)
        {
            return nameof(FromTreadmillStressTest) + " in " + nameof(CalculateVo2Max) + 
                   " does not yet implement handling of the protocol described by " + protocol + ".";
        }

        private static FitnessClassification Classify(double vo2Max, IPatient patient)
        {
            if (patient.Age < 13)
                throw new ArgumentException("Age must be 13 or greater.");
            return Gender.IsGenotypeXx(patient.Gender) 
                ? GetFemaleClassification(vo2Max, patient.Age) : GetMaleClassification(vo2Max, patient.Age);
        }

        private static FitnessClassification GetMaleClassification(double vo2Max, double ageInYears)
        {
            if (ageInYears <= 25)
                return MaleUnder25Classification(vo2Max);
            if (ageInYears <= 35)
                return MaleUnder35Classification(vo2Max);
            if (ageInYears <= 45)
                return MaleUnder45Classification(vo2Max);
            if (ageInYears <= 55)
                return MaleUnder55Classification(vo2Max);
            return ageInYears <= 65 ? MaleUnder65Classification(vo2Max) : MaleOver65Classification(vo2Max);
        }

        private static FitnessClassification MaleOver65Classification(double vo2Max)
        {
            if (vo2Max > 37)
        
                return FitnessClassification.Excellent;
            if (vo2Max >= 33)
                return FitnessClassification.Good;
            if (vo2Max >= 29)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 26)
                return FitnessClassification.Average;
            if (vo2Max >= 22)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 20 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification MaleUnder65Classification(double vo2Max)
        {
            if (vo2Max > 41)
                return FitnessClassification.Excellent;
            if (vo2Max >= 36)
                return FitnessClassification.Good;
            if (vo2Max >= 32)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 30)
                return FitnessClassification.Average;
            if (vo2Max >= 26)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 22 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification MaleUnder55Classification(double vo2Max)
        {
            if (vo2Max > 45)
                return FitnessClassification.Excellent;
            if (vo2Max >= 39)
                return FitnessClassification.Good;
            if (vo2Max >= 36)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 32)
                return FitnessClassification.Average;
            if (vo2Max >= 29)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 25 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification MaleUnder45Classification(double vo2Max)
        {
            if (vo2Max > 51)
                return FitnessClassification.Excellent;
            if (vo2Max >= 43)
                return FitnessClassification.Good;
            if (vo2Max >= 39)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 35)
                return FitnessClassification.Average;
            if (vo2Max >= 31)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 26 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification MaleUnder35Classification(double vo2Max)
        {
            if (vo2Max > 56)
                return FitnessClassification.Excellent;
            if (vo2Max >= 49)
                return FitnessClassification.Good;
            if (vo2Max >= 43)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 40)
                return FitnessClassification.Average;
            if (vo2Max >= 35)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 30 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification MaleUnder25Classification(double vo2Max)
        {
            if (vo2Max > 60)
                return FitnessClassification.Excellent;
            if (vo2Max >= 52)
                return FitnessClassification.Good;
            if (vo2Max >= 47)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 42)
                return FitnessClassification.Average;
            if (vo2Max >= 37)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 30 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification GetFemaleClassification(double vo2Max, double ageInYears)
        {
            if (ageInYears <= 25)
                return FemaleUnder25Classification(vo2Max);
            if (ageInYears <= 35)
                return FemaleUnder35Classification(vo2Max);
            if (ageInYears <= 45)
                return FemaleUnder45Classification(vo2Max);
            if (ageInYears <= 55)
                return FemaleUnder55Classification(vo2Max);
            return ageInYears <= 65 ? FemaleUnder65Classification(vo2Max) : FemaleOver65Classification(vo2Max);
        }
        
        private static FitnessClassification FemaleOver65Classification(double vo2Max)
        {
            if (vo2Max > 32)
                return FitnessClassification.Excellent;
            if (vo2Max >= 28)
                return FitnessClassification.Good;
            if (vo2Max >= 25)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 22)
                return FitnessClassification.Average;
            if (vo2Max >= 19)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 17 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification FemaleUnder65Classification(double vo2Max)
        {
            if (vo2Max > 37)
                return FitnessClassification.Excellent;
            if (vo2Max >= 32)
                return FitnessClassification.Good;
            if (vo2Max >= 28)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 25)
                return FitnessClassification.Average;
            if (vo2Max >= 22)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 18 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification FemaleUnder55Classification(double vo2Max)
        {
            if (vo2Max > 40)
                return FitnessClassification.Excellent;
            if (vo2Max >= 34)
                return FitnessClassification.Good;
            if (vo2Max >= 31)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 28)
                return FitnessClassification.Average;
            if (vo2Max >= 25)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 20 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification FemaleUnder45Classification(double vo2Max)
        {
            if (vo2Max > 45)
                return FitnessClassification.Excellent;
            if (vo2Max >= 38)
                return FitnessClassification.Good;
            if (vo2Max >= 34)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 31)
                return FitnessClassification.Average;
            if (vo2Max >= 27)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 22 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification FemaleUnder35Classification(double vo2Max)
        {
            if (vo2Max > 52)
                return FitnessClassification.Excellent;
            if (vo2Max >= 45)
                return FitnessClassification.Good;
            if (vo2Max >= 39)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 35)
                return FitnessClassification.Average;
            if (vo2Max >= 31)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 26 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }

        private static FitnessClassification FemaleUnder25Classification(double vo2Max)
        {
            if (vo2Max > 56)
                return FitnessClassification.Excellent;
            if (vo2Max >= 47)
                return FitnessClassification.Good;
            if (vo2Max >= 42)
                return FitnessClassification.AboveAverage;
            if (vo2Max >= 38)
                return FitnessClassification.Average;
            if (vo2Max >= 33)
                return FitnessClassification.BelowAverage;
            return vo2Max >= 28 ? FitnessClassification.Poor : FitnessClassification.VeryPoor;
        }
    }
}