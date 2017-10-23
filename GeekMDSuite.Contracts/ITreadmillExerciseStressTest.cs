namespace GeekMDSuite.Contracts
{
    public interface ITreadmillExerciseStressTest
    {
        TreadmillExerciseStressTestProtocol Protocol { get; }
        TreadmillExerciseStressTestResultFlag  Flag { get; }
        int Minutes { get;}
        int Seconds { get;}
        int HeartRateResting { get; }
        double HeartRateMaxReached { get; }
        double HeartRateMaxPredicted { get; }
        string ClinicianComments { get; }
    }
    public enum TreadmillExerciseStressTestProtocol
    {
        Bruce = 0,
        BruceLowLevel = 1,
        ModifiedBruce = 2,
        Balke3Point0 = 3,
        Balke3Point4 = 4,
        Cornell = 5,
        Ellstad = 6,
        Kattus = 7,
        Naughton = 8,
        UsAirforceSam20 = 9,
        UsAirforceSam33 = 10
    }
    public enum TreadmillExerciseStressTestResultFlag
    {
        NoneSelected = 0,
        Normal = 1,
        Ischemia = 2,
        Abnormal = 3,
        Indeterminant = 4,
        Incomplete = 5,
        Other = 6
    }
}