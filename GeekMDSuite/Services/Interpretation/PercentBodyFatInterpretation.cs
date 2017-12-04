using System;

namespace GeekMDSuite.Services.Interpretation
{
    public class PercentBodyFatInterpretation : IInterpretable<PercentBodyFatClassification>
    {
        public PercentBodyFatInterpretation(IBodyCompositionExpanded bodyCompositionExpanded, GenderIdentity genderIdentity)
        {
            _genderIdentity = genderIdentity;
            Value = bodyCompositionExpanded.PercentBodyFat;
        }
        public InterpretationText Interpretation => throw new NotImplementedException();
        public double Value { get; }
        
        public PercentBodyFatClassification Classification => ClassifyPercentBodyFat();

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
        
        private readonly GenderIdentity _genderIdentity;
        
        private PercentBodyFatClassification ClassifyPercentBodyFat()
        {
            var upperLimit = DetermineBodyFatLimitsByGender(_genderIdentity);

            if (Value < upperLimit.Athletic)
                return PercentBodyFatClassification.UnderFat;
            if (Value < upperLimit.Fitness)
                return PercentBodyFatClassification.Athletic;
            if (Value < upperLimit.Acceptable)
                return PercentBodyFatClassification.Fitness;
            return Value < upperLimit.OverFat ? PercentBodyFatClassification.Acceptable : PercentBodyFatClassification.OverFat;
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