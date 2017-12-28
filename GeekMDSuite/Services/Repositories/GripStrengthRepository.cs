using GeekMDSuite.Services.Interpretation;
using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Services.Repositories
{
    internal static class GripStrengthRepository
    {
        private static IPatient _patient;

        public static GripStrengthLimits GetRanges(IPatient patient)
        {
            _patient = patient;
            return Gender.IsGenotypeXy(patient.Gender) ? MapMaleLimits() : MapFemaleLimits();
        }

        private static GripStrengthLimits MapFemaleLimits()
        {
            if (InAgeRange(10,11)) return GenerateGripStrengthLimits(11.8,21.6);
            if (InAgeRange(12,13)) return GenerateGripStrengthLimits(14.6,24.4);
            if (InAgeRange(14,15)) return GenerateGripStrengthLimits(15.5,27.3);
            if (InAgeRange(16,17)) return GenerateGripStrengthLimits(17.2,29.0);
            if (InAgeRange(18,19)) return GenerateGripStrengthLimits(19.2,31.0);
            if (InAgeRange(20,24)) return GenerateGripStrengthLimits(21.5,35.3);
            if (InAgeRange(25,29)) return GenerateGripStrengthLimits(25.6,41.4);
            if (InAgeRange(30,34)) return GenerateGripStrengthLimits(21.5,35.3);
            if (InAgeRange(35,39)) return GenerateGripStrengthLimits(20.3,34.1);
            if (InAgeRange(40,44)) return GenerateGripStrengthLimits(18.9,32.7);
            if (InAgeRange(45,49)) return GenerateGripStrengthLimits(18.6,32.4);
            if (InAgeRange(50,54)) return GenerateGripStrengthLimits(18.1,31.9);
            if (InAgeRange(50,59)) return GenerateGripStrengthLimits(17.7,31.5);
            if (InAgeRange(60,64)) return GenerateGripStrengthLimits(17.2,31.0);
            return InAgeRange(65,69) ? GenerateGripStrengthLimits(15.4,24.5) 
                : GenerateGripStrengthLimits(14.7,24.5);
        }

        private static GripStrengthLimits MapMaleLimits()
        {
            if (InAgeRange(10,11)) return GenerateGripStrengthLimits(12.6, 22.4);
            if (InAgeRange(12,13)) return GenerateGripStrengthLimits(19.4,31.2);
            if (InAgeRange(14,15)) return GenerateGripStrengthLimits(28.5,44.3);
            if (InAgeRange(16,17)) return GenerateGripStrengthLimits(32.6,52.4);
            if (InAgeRange(18,19)) return GenerateGripStrengthLimits(35.7,55.5);
            if (InAgeRange(20,24)) return GenerateGripStrengthLimits(36.8,56.6);
            if (InAgeRange(25,29)) return GenerateGripStrengthLimits(37.7,57.5);
            if (InAgeRange(30,34)) return GenerateGripStrengthLimits(36.0,55.8);
            if (InAgeRange(35,39)) return GenerateGripStrengthLimits(35.8,55.6);
            if (InAgeRange(40,44)) return GenerateGripStrengthLimits(35.5, 55.3);
            if (InAgeRange(45,49)) return GenerateGripStrengthLimits(34.7,54.5);
            if (InAgeRange(50,54)) return GenerateGripStrengthLimits(32.9,50.7);
            if (InAgeRange(50,59)) return GenerateGripStrengthLimits(30.7,48.5);
            if (InAgeRange(60,64)) return GenerateGripStrengthLimits(30.2,48.0);
            return InAgeRange(65,69) ? GenerateGripStrengthLimits(28.2,44.0) 
                : GenerateGripStrengthLimits(21.3, 35.1);
        }

        private static bool InAgeRange(int lower, int upper) => 
            Interval<int>.Create(lower, upper).ContainsClosed(_patient.Age);

        private static GripStrengthLimits GenerateGripStrengthLimits(double lowerKilograms, double upperKilograms) =>
            GripStrengthLimits.BuildFromKilogramsInput(lowerKilograms, upperKilograms);
    }
}
