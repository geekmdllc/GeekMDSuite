namespace GeekMDSuite.Contracts.Procedures
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
}