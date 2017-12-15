using System;

namespace GeekMDSuite.Services.Repositories.MusculoskeletalStrengthTests
{
    internal abstract class MuscularStrengthRepository
    {
        
        protected static Func<MuscularStrengthRepositoryEntry, bool> BelongsToAgeCategory(IPatient patient)
        {
            return entry => entry.AgeRange.ContainsOpen(patient.Age);
        }
    }
}