using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Services.Repositories
{
    internal static class SitupsRepository 
    {
        public static MuscularStrengthRepositoryEntry GetRanges(IPatient patient)
        {
            var values = Gender.IsGenotypeXy(patient.Gender)
                ? Male.List.FirstOrDefault(entry => entry.AgeRange.ContainsClosed(patient.Age))
                : Female.List.FirstOrDefault(entry => entry.AgeRange.ContainsClosed(patient.Age));

            return values;
        }

        private static class Male
        {
            public static readonly List<MuscularStrengthRepositoryEntry> List = new List<MuscularStrengthRepositoryEntry>() {
                AgeLessThanMax(),
                AgeLessThan60(),
                AgeLessThan50(),
                AgeLessThan40(), 
                AgeLessThan30(),
                AgeLessThan20(),
            };

            private static MuscularStrengthRepositoryEntry AgeLessThan20() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(0,19), 25, 31, 35, 39, 44, 49);

            private static MuscularStrengthRepositoryEntry AgeLessThan30() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(20,29), 22, 29, 31, 35, 40, 45);

            private static MuscularStrengthRepositoryEntry AgeLessThan40() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(30, 39), 17, 23, 27, 30, 35, 41);

            private static MuscularStrengthRepositoryEntry AgeLessThan50() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(40,49), 13, 18, 22, 25, 29, 35);

            private static MuscularStrengthRepositoryEntry AgeLessThan60() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(50,59),  9, 13, 17, 21, 25, 31);

            private static MuscularStrengthRepositoryEntry AgeLessThanMax() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(60,int.MaxValue),  7, 11, 15, 19, 22, 28);
        }

        private static class Female
        {
            public static readonly List<MuscularStrengthRepositoryEntry> List = new List<MuscularStrengthRepositoryEntry>() {
                AgeLessThanMax(),
                AgeLessThan60(),
                AgeLessThan50(),
                AgeLessThan40(), 
                AgeLessThan30(),
                AgeLessThan20(),
            };

            private static MuscularStrengthRepositoryEntry AgeLessThan20() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(0,19), 18,  25, 29, 33, 37, 43);

            private static MuscularStrengthRepositoryEntry AgeLessThan30() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(20,29), 13,  21, 25, 29, 33, 39);

            private static MuscularStrengthRepositoryEntry AgeLessThan40() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(30,39),  7,  15, 19, 23, 27, 33);

            private static MuscularStrengthRepositoryEntry AgeLessThan50() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(40,49),  5,  10, 14, 18, 22, 27);

            private static MuscularStrengthRepositoryEntry AgeLessThan60() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(50,59),  3,   7, 10, 13, 18, 24);

            private static MuscularStrengthRepositoryEntry AgeLessThanMax() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(60,int.MaxValue),  2,   5, 11, 14, 17, 23);
        }
    }
}