using GeekMDSuite.Common.Models;

namespace GeekMDSuite.Interpretation.BodyComposition
{
    public static class PercentBodyFat
    {       
        public static PercentBodyFatClassification Interpret (IPatient patient) => Classify(patient);

        private static PercentBodyFatClassification Classify(IPatient patient)
        {
            var upperLimit = DetermineBodyFatLimitsByGender(patient.Gender);

            if (patient.PercentBodyFat < upperLimit.Athletic)
                return PercentBodyFatClassification.UnderFat;
            if (patient.PercentBodyFat < upperLimit.Fitness)
                return PercentBodyFatClassification.Athletic;
            if (patient.PercentBodyFat < upperLimit.Athletic)
                return PercentBodyFatClassification.Fitness;
            return patient.PercentBodyFat < upperLimit.OverFat ? PercentBodyFatClassification.Acceptable : PercentBodyFatClassification.OverFat;
        }

        private static BodyFatLimits DetermineBodyFatLimitsByGender(Gender gender)
        {
            var athletic = Gender.IsGenotypeXy(gender) ? AthleticMaleLLN : AthleticFemaleLLN;
            var fitness = Gender.IsGenotypeXy(gender) ? FitMaleLLN : FitFemaleLLN;
            var acceptable = Gender.IsGenotypeXy(gender) ? AcceptableMaleLLN : AcceptableFemaleLLN;
            var overfat = Gender.IsGenotypeXy(gender) ? OverFatMaleLLN : OverFatFemaleLLN;
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