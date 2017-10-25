namespace GeekMDSuite.Contracts
{
    public interface ITreadmillExerciseStressTest
    {
        TreadmillExerciseStressTestProtocol Protocol { get; }
        TreadmillExerciseStressTestResultFlag  Flag { get; }
        TimeDuration TimeDuration { get; }
        double HeartRateResting { get; }
        double HeartRateMaxReached { get; }
        double HeartRateMaxPredicted { get; }
        string ClinicianComments { get; }
    }
}