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
        double HeartRatePercentReachedOfMaxPredicted { get; }
        string ClinicianComments { get; }
    }
    public enum TreadmillExerciseStressTestProtocol
    {
        NoneSelected,
        Bruce,
        BruceLowLevel,
        ModifiedBruce,
        Balke3Point0,
        Balke3Point4,
        Cornell,
        Ellstad,
        Kattus,
        Naughton,
        UsAirforceSam20,
        UsAirforceSam33
    }
    public enum TreadmillExerciseStressTestResultFlag
    {
        NoneSelected,
        Normal,
        Ischemia,
        Abnormal,
        Other
    }
}