using GeekMDSuite.Services.Interpretation;

namespace GeekMDSuite.Services.Repositories.MusculoskeletalStrengthTests
{
    public class MuscularStrengthRepositoryEntry : IStrengthTestRanges
    {
        public MuscularStrengthRepositoryEntry(int ageLowerLimit, 
            int lowerLimitOfPoor, 
            int lowerLimitOfBelowAverage, 
            int lowerLimitOfAverage, 
            int lowerLimitOfAboveAverage, 
            int lowerLimitOfGood, 
            int lowerLimitOfExcellent)
        {
            AgeLowerLimit = ageLowerLimit;
            LowerLimitOfPoor = lowerLimitOfPoor;
            LowerLimitOfBelowAverage = lowerLimitOfBelowAverage;
            LowerLimitOfAverage = lowerLimitOfAverage;
            LowerLimitOfAboveAverage = lowerLimitOfAboveAverage;
            LowerLimitOfGood = lowerLimitOfGood;
            LowerLimitOfExcellent = lowerLimitOfExcellent;
        }

        public int AgeLowerLimit { get; }
        public int LowerLimitOfPoor { get; }
        public int LowerLimitOfBelowAverage { get; }
        public int LowerLimitOfAverage { get; }
        public int LowerLimitOfAboveAverage { get; }
        public int LowerLimitOfGood { get; }
        public int LowerLimitOfExcellent { get; }
    }
}