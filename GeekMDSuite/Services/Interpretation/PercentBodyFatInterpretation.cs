using System;

namespace GeekMDSuite.Services.Interpretation
{
    public class PercentBodyFatInterpretation : IInterpretable<PercentBodyFat>
    {
        public PercentBodyFatInterpretation(IBodyCompositionExpanded bodyCompositionExpanded, IPatient patient)
        {
            if (bodyCompositionExpanded == null) throw new ArgumentNullException(nameof(bodyCompositionExpanded));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            Value = bodyCompositionExpanded.PercentBodyFat;
        }
        public InterpretationText Interpretation => throw new NotImplementedException();
        public double Value { get; }
        
        public PercentBodyFat Classification => Classify();

        public override string ToString() => Classification.ToString();

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
        
        private readonly IPatient _patient;
        
        private PercentBodyFat Classify()
        {
            var upperLimit = DetermineBodyFatLimitsByGender(_patient.Gender);

            if (Value < upperLimit.Athletic)
                return PercentBodyFat.UnderFat;
            if (Value < upperLimit.Fitness)
                return PercentBodyFat.Athletic;
            if (Value < upperLimit.Acceptable)
                return PercentBodyFat.Fitness;
            return Value < upperLimit.OverFat ? PercentBodyFat.Acceptable : PercentBodyFat.OverFat;
        }

        private static BodyFatLimits DetermineBodyFatLimitsByGender(IGender gender)
        {
            var genotypeIsXy = Gender.IsGenotypeXy(gender);
            
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