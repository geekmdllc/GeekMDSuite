using System.Collections.Generic;
using System.Linq;

namespace GeekMDSuite.Services.Repositories.MusculoskeletalStrengthTests
{
    public static class SitupsRepository
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
                GetMaleAgeLessThanMax()
            };

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan20() => 
                new MuscularStrengthRepositoryEntry(20, 25, 31, 35, 39, 44, 49);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan30() => 
                new MuscularStrengthRepositoryEntry(30, 22, 29, 31, 35, 40, 45);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan40() => 
                new MuscularStrengthRepositoryEntry(40, 17, 23, 27, 30, 35, 41);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan50() => 
                new MuscularStrengthRepositoryEntry(50, 13, 18, 22, 25, 29, 35);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan60() => 
                new MuscularStrengthRepositoryEntry(60,  9, 13, 17, 21, 25, 31);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThanMax() => 
                new MuscularStrengthRepositoryEntry(int.MaxValue,  7, 11, 15, 19, 22, 28);
        }

        private static class Female
        {
            public static readonly List<MuscularStrengthRepositoryEntry> List = new List<MuscularStrengthRepositoryEntry>() {
                GetFemaleAgeLessThan20(),
                GetFemaleAgeLessThan30(),
                GetFemaleAgeLessThan40(), 
                GetFemaleAgeLessThan50(),
                GetFemaleAgeLessThan60(),
                GetFemaleAgeLessThanMax()
            };

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan20() => 
                new MuscularStrengthRepositoryEntry(20, 18,  25, 29, 33, 37, 43);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan30() => 
                new MuscularStrengthRepositoryEntry(30, 13,  21, 25, 29, 33, 39);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan40() => 
                new MuscularStrengthRepositoryEntry(40,  7,  15, 19, 23, 27, 33);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan50() => 
                new MuscularStrengthRepositoryEntry(50,  5,  10, 14, 18, 22, 27);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan60() => 
                new MuscularStrengthRepositoryEntry(60,  3,   7, 10, 13, 18, 24);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThanMax() => 
                new MuscularStrengthRepositoryEntry(int.MaxValue,  2,   5, 11, 14, 17, 23);
        }
    }
}