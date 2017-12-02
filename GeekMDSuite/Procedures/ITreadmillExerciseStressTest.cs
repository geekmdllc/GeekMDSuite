using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Procedures
{
    public interface ITreadmillExerciseStressTest
    {
        TreadmillProtocol Protocol { get; }
        ITimeDuration Time { get; }
        TreadmillExerciseStressTestResultClassification Result { get; }
        BloodPressure SupineBloodPressure { get; }
        int SupineHeartRate { get; }
        BloodPressure MaximumBloodPressure { get; }
        int MaximumHeartRate { get; }
    }
}