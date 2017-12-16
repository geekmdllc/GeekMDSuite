using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Services.Repositories.MusculoskeletalStrengthTests
{
    internal static class SitAndReachRepository
    {
        
        public static MuscularStrengthRepositoryEntry GetRanges(IPatient patient) => 
            Gender.IsGenotypeXy(patient.Gender) ? Male.Ranges : Female.Ranges;

        private static class Male
        {
            private const int LowerLimitOfPoor = -20;
            private const int LowerLimitOfBelowAverage = -8;
            private const int LowerLimitOfAverage = 0;
            private const int LowerLimitOfAboveAverage = 6;
            private const int LowerLimitOfGood = 17;
            private const int LowerLimitOfExcellent = 28;

            public static MuscularStrengthRepositoryEntry Ranges =>
                new MuscularStrengthRepositoryEntry(
                    new Interval<int>(0,999), 
                    LowerLimitOfPoor,
                    LowerLimitOfBelowAverage,
                    LowerLimitOfAverage,
                    LowerLimitOfAboveAverage,
                    LowerLimitOfGood,
                    LowerLimitOfExcellent);
        }

        private static class Female
        {
            private const int LowerLimitOfPoor = -15;
            private const int LowerLimitOfBelowAverage = -7;
            private const int LowerLimitOfAverage = 1;
            private const int LowerLimitOfAboveAverage = 11;
            private const int LowerLimitOfGood = 21;
            private const int LowerLimitOfExcellent = 30;

            public static MuscularStrengthRepositoryEntry Ranges =>
                new MuscularStrengthRepositoryEntry(
                    new Interval<int>(0,999), 
                    LowerLimitOfPoor,
                    LowerLimitOfBelowAverage,
                    LowerLimitOfAverage,
                    LowerLimitOfAboveAverage,
                    LowerLimitOfGood,
                    LowerLimitOfExcellent);
        }
    }
}