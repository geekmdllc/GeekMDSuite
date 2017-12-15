using GeekMDSuite.Services.Interpretation;
using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.Services.Repositories.MusculoskeletalStrengthTests
{
    public class MuscularStrengthRepositoryEntry : IStrengthTestRanges
    {
        public MuscularStrengthRepositoryEntry(Interval<int> ageRange, 
            int lowerLimitOfPoor, 
            int lowerLimitOfBelowAverage, 
            int lowerLimitOfAverage, 
            int lowerLimitOfAboveAverage, 
            int lowerLimitOfGood, 
            int lowerLimitOfExcellent)
        {
            AgeRange = ageRange;
            LowerLimitOfPoor = lowerLimitOfPoor;
            LowerLimitOfBelowAverage = lowerLimitOfBelowAverage;
            LowerLimitOfAverage = lowerLimitOfAverage;
            LowerLimitOfAboveAverage = lowerLimitOfAboveAverage;
            LowerLimitOfGood = lowerLimitOfGood;
            LowerLimitOfExcellent = lowerLimitOfExcellent;
        }

        public Interval<int> AgeRange { get; }
        public int LowerLimitOfPoor { get; }
        public int LowerLimitOfBelowAverage { get; }
        public int LowerLimitOfAverage { get; }
        public int LowerLimitOfAboveAverage { get; }
        public int LowerLimitOfGood { get; }
        public int LowerLimitOfExcellent { get; }
    }
}