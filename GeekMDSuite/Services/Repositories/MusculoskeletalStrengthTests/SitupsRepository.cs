using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Services.Repositories.MusculoskeletalStrengthTests
{
    internal class SitupsRepository : MuscularStrengthRepository
    {
        public static MuscularStrengthRepositoryEntry GetValues(IPatient patient)
        {
            var maleList = Male.List;
            var femaleList = Female.List;
            
            var found =  Gender.IsGenotypeXy(patient.Gender)
                ? Male.List.FirstOrDefault(entry => entry.AgeRange.ContainsOpen(patient.Age))
                : Female.List.FirstOrDefault(entry => entry.AgeRange.ContainsOpen(patient.Age));

            return found;
        }

        private static class Male
        {
            public static readonly List<MuscularStrengthRepositoryEntry> List = new List<MuscularStrengthRepositoryEntry>() {
                GetMaleAgeLessThanMax(),
                GetMaleAgeLessThan60(),
                GetMaleAgeLessThan50(),
                GetMaleAgeLessThan40(), 
                GetMaleAgeLessThan30(),
                GetMaleAgeLessThan20(),
            };

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan20() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(0,19), 25, 31, 35, 39, 44, 49);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan30() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(20,29), 22, 29, 31, 35, 40, 45);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan40() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(30,39), 17, 23, 27, 30, 35, 41);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan50() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(40,49), 13, 18, 22, 25, 29, 35);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThan60() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(50,59),  9, 13, 17, 21, 25, 31);

            private static MuscularStrengthRepositoryEntry GetMaleAgeLessThanMax() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(60,int.MaxValue),  7, 11, 15, 19, 22, 28);
        }

        private static class Female
        {
            public static readonly List<MuscularStrengthRepositoryEntry> List = new List<MuscularStrengthRepositoryEntry>() {
                GetFemaleAgeLessThanMax(),
                GetFemaleAgeLessThan60(),
                GetFemaleAgeLessThan50(),
                GetFemaleAgeLessThan40(), 
                GetFemaleAgeLessThan30(),
                GetFemaleAgeLessThan20(),
            };

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan20() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(0,19), 18,  25, 29, 33, 37, 43);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan30() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(20,29), 13,  21, 25, 29, 33, 39);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan40() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(30,39),  7,  15, 19, 23, 27, 33);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan50() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(40,49),  5,  10, 14, 18, 22, 27);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThan60() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(50,59),  3,   7, 10, 13, 18, 24);

            private static MuscularStrengthRepositoryEntry GetFemaleAgeLessThanMax() => 
                new MuscularStrengthRepositoryEntry(new Interval<int>(60,int.MaxValue),  2,   5, 11, 14, 17, 23);
        }
    }
}