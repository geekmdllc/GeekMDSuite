using System;

namespace GeekMDSuite.Services.Repositories.MusculoskeletalStrengthTests
{
    internal abstract class MuscularStrengthRepository
    {
        
        protected static Func<MuscularStrengthRepositoryEntry, bool> AgeCheck(IPatient patient)
        {
            return p => p.AgeRange.ContainsOpen(patient.Age);
        }
    }
}