using System.Collections.Generic;
using System.Linq;

namespace GeekMDSuite.Services.Repositories.MusculoskeletalStrengthTests
{
    internal static class PushupsRepository
    {
        public static MuscularStrengthRepositoryEntry GetValues(IPatient patient)
        {
            return Gender.IsGenotypeXy(patient.Gender) 
                ? Male.List.First(p => p.AgeLowerLimit < patient.Age)
                : Female.List.First(p => p.AgeLowerLimit < patient.Age);
        }

        private static class Male
        {
            public static readonly List<MuscularStrengthRepositoryEntry> List = new List<MuscularStrengthRepositoryEntry>() {
                GetMaleAgeLessThan20(),
                GetMaleAgeLessThan30(),
                GetMaleAgeLessThan40(), 
                GetMaleAgeLessThan50(),
                GetMaleAgeLessThan60(),
                GetMaleAgeLessThan999()
            };
            
            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan20() => 
                new MuscularStrengthRepositoryEntry(20, 4, 11, 19, 35, 47, 56);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan30() => 
                new MuscularStrengthRepositoryEntry(30, 4, 10, 17, 30, 39, 47);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan40() => 
                new MuscularStrengthRepositoryEntry(40, 2,  8, 13, 25, 34, 41);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan50() => 
                new MuscularStrengthRepositoryEntry(50, 1,  6, 11, 21, 28, 34);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan60() => 
                new MuscularStrengthRepositoryEntry(60, 1,  5,  9, 18, 25, 31);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan999() => 
                new MuscularStrengthRepositoryEntry(999, 1,  3,  6, 17, 24, 30);
        }

        private static class Female
        {
            public static readonly List<MuscularStrengthRepositoryEntry> List = new List<MuscularStrengthRepositoryEntry>() {
                GetFemaleAgeLessThan20(),
                GetFemaleAgeLessThan30(),
                GetFemaleAgeLessThan40(), 
                GetFemaleAgeLessThan50(),
                GetFemaleAgeLessThan60(),
                GetFemaleAgeLessThan999()
            };

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan20() => 
                new MuscularStrengthRepositoryEntry(20, 2,  6, 11, 21, 27, 35);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan30() => 
                new MuscularStrengthRepositoryEntry(30, 2,  7, 12, 23, 30, 36);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan40() => 
                new MuscularStrengthRepositoryEntry(40, 1,  5, 10, 22, 30, 37);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan50() => 
                new MuscularStrengthRepositoryEntry(50, 1,  4,  8, 18, 25, 31);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan60() => 
                new MuscularStrengthRepositoryEntry(60, 1,  3,  7, 15, 21, 25);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan999() => 
                new MuscularStrengthRepositoryEntry(999, 1,  2,  5, 13, 19, 23);
        }
    }
}