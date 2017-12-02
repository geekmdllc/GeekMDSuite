using System;
using GeekMDSuite.Tools;

namespace GeekMDSuite.Services.Interpretation
{
    public class PercentBodyFatInterpretation : IInterpretable
    {
        public PercentBodyFatInterpretation(double percentBodyFat, GenderIdentity genderIdentity)
        {
            _genderIdentity = genderIdentity;
            _percentBodyFat = percentBodyFat;
        }
        public InterpretationText Interpretation => throw new NotImplementedException();
        public double Value => _percentBodyFat;
        
        public static PercentBodyFatClassification Interpret (double percentBodyFat, GenderIdentity genderIdentity) => 
            Classify(percentBodyFat, genderIdentity);

        private static PercentBodyFatClassification Classify(double percentBodyFat, GenderIdentity genderIdentity)
        {
            var upperLimit = DetermineBodyFatLimitsByGender(percentBodyFat, genderIdentity);

            if (percentBodyFat < upperLimit.Athletic)
                return PercentBodyFatClassification.UnderFat;
            if (percentBodyFat < upperLimit.Fitness)
                return PercentBodyFatClassification.Athletic;
            if (percentBodyFat < upperLimit.Acceptable)
                return PercentBodyFatClassification.Fitness;
            return percentBodyFat < upperLimit.OverFat ? PercentBodyFatClassification.Acceptable : PercentBodyFatClassification.OverFat;
        }

        private static BodyFatLimits DetermineBodyFatLimitsByGender(double percentBodyFat, GenderIdentity genderIdentity)
        {
            var genotypeIsXy = Gender.IsGenotypeXy(genderIdentity);
            
            var athletic = genotypeIsXy ? AthleticMaleLLN : AthleticFemaleLLN;
            var fitness = genotypeIsXy ? FitMaleLLN : FitFemaleLLN;
            var acceptable = genotypeIsXy ? AcceptableMaleLLN : AcceptableFemaleLLN;
            var overfat = genotypeIsXy ? OverFatMaleLLN : OverFatFemaleLLN;
            return new BodyFatLimits(athletic, fitness, acceptable, overfat);
        }

        public static double AthleticMaleLLN = 6;
        public static double AthleticFemaleLLN = 14;
        public static double FitMaleLLN = 14;
        public static double FitFemaleLLN = 21;
        public static double AcceptableMaleLLN = 18;
        public static double AcceptableFemaleLLN = 25;
        public static double OverFatMaleLLN = 25;
        public static double OverFatFemaleLLN = 32;
        
        private double _percentBodyFat;
        private GenderIdentity _genderIdentity;

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