using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Services.Repositories.MusculoskeletalStrengthTests
{
    internal static class SitAndReachRepository
    {
        
        public static MuscularStrengthRepositoryEntry GetRanges(IPatient patient) => 
            Gender.IsGenotypeXy(patient.Gender) ? Male.Ranges : Female.Ranges;

        private static class Male
        {
            public static MuscularStrengthRepositoryEntry Ranges =>
                new MuscularStrengthRepositoryEntry(AgeRange, -20, -8, 0, 6, 17, 28);
        }

        private static class Female
        {
            public static MuscularStrengthRepositoryEntry Ranges =>
                new MuscularStrengthRepositoryEntry(AgeRange, -15, -7, 1, 11, 21, 30);
        }
        
        private static Interval<int> AgeRange => Interval<int>.Create(0,999);
    }
}