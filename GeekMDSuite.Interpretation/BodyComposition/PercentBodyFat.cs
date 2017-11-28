using System;
using GeekMDSuite.Common.Models;

namespace GeekMDSuite.Interpretation.BodyComposition
{
    public class PercentBodyFat : IInterpretable
    {
        public Interpretation Interpretation => throw new NotImplementedException();
        
        public static PercentBodyFatClassification Interpret (IPatient patient) => Classify(patient);

        private static PercentBodyFatClassification Classify(IPatient patient)
        {
            var upperLimit = DetermineBodyFatLimitsByGender(patient);

            if (patient.PercentBodyFat < upperLimit.Athletic)
                return PercentBodyFatClassification.UnderFat;
            if (patient.PercentBodyFat < upperLimit.Fitness)
                return PercentBodyFatClassification.Athletic;
            if (patient.PercentBodyFat < upperLimit.Acceptable)
                return PercentBodyFatClassification.Fitness;
            return patient.PercentBodyFat < upperLimit.OverFat ? PercentBodyFatClassification.Acceptable : PercentBodyFatClassification.OverFat;
        }

        private static BodyFatLimits DetermineBodyFatLimitsByGender(IPatient patient)
        {
            var genotypeXy = Gender.IsGenotypeXy(patient.Gender);
            
            var athletic = genotypeXy ? AthleticMaleLLN : AthleticFemaleLLN;
            var fitness = genotypeXy ? FitMaleLLN : FitFemaleLLN;
            var acceptable = genotypeXy ? AcceptableMaleLLN : AcceptableFemaleLLN;
            var overfat = genotypeXy ? OverFatMaleLLN : OverFatFemaleLLN;
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
        private Interpretation _interpretation;

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