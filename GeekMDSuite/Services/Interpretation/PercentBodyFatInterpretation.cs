using System;

namespace GeekMDSuite.Services.Interpretation
{
    public class PercentBodyFatInterpretation : IInterpretable
    {
        // TODO: This needs to be reworked to be consistnet with rest of API.
        private readonly GenderIdentity _genderIdentity;

        public PercentBodyFatInterpretation(double percentBodyFat, GenderIdentity genderIdentity)
        {
            _genderIdentity = genderIdentity;
            Value = percentBodyFat;
        }
        public InterpretationText Interpretation => throw new NotImplementedException();
        public double Value { get; }
        
        public static PercentBodyFatClassification Interpret (double percentBodyFat, GenderIdentity genderIdentity) => 
            Classify(percentBodyFat, genderIdentity);

        private static PercentBodyFatClassification Classify(double percentBodyFat, GenderIdentity genderIdentity)
        {
            var upperLimit = DetermineBodyFatLimitsByGender(genderIdentity);

            if (percentBodyFat < upperLimit.Athletic)
                return PercentBodyFatClassification.UnderFat;
            if (percentBodyFat < upperLimit.Fitness)
                return PercentBodyFatClassification.Athletic;
            if (percentBodyFat < upperLimit.Acceptable)
                return PercentBodyFatClassification.Fitness;
            return percentBodyFat < upperLimit.OverFat ? PercentBodyFatClassification.Acceptable : PercentBodyFatClassification.OverFat;
        }

        private static BodyFatLimits DetermineBodyFatLimitsByGender(GenderIdentity genderIdentity)
        {
            var genotypeIsXy = Gender.IsGenotypeXy(genderIdentity);
            
            var athletic = genotypeIsXy ? LowerLimits.Male.Athletic : LowerLimits.Female.Athletic;
            var fitness = genotypeIsXy ? LowerLimits.Male.Fit : LowerLimits.Female.Fit;
            var acceptable = genotypeIsXy ? LowerLimits.Male.Acceptable : LowerLimits.Female.Acceptable;
            var overfat = genotypeIsXy ? LowerLimits.Male.OverFat : LowerLimits.Female.OverFat;
            return new BodyFatLimits(athletic, fitness, acceptable, overfat);
        }

        public static class LowerLimits
        {
            public static class Male
            {
                public const double Athletic = 6;
                public const double Fit = 14;
                public const double Acceptable = 18;
                public const double OverFat = 25;
            }

            public static class Female
            {
                public const double Athletic = 14;
                public const double Fit = 21;
                public const double Acceptable = 25;
                public const double OverFat = 32;
            }
        }

        private class BodyFatLimits
        {
            public BodyFatLimits(double athletic, double fitness, double acceptable, double overFat)
            {
                Athletic = athletic;
                Fitness = fitness;
                Acceptable = acceptable;
                OverFat = overFat;
            }
            internal double Athletic { get; }
            internal double Fitness { get; }
            internal double Acceptable { get; }
            internal double OverFat { get; }
        }

    }
}