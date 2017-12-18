using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Procedures
{
    public class TreadmillExerciseStressTest : ITreadmillExerciseStressTest
    {
        public TreadmillProtocol Protocol { get; }
        public ITimeDuration Time { get; }
        public TreadmillExerciseStressTestResultClassification Result { get; }
        public BloodPressure SupineBloodPressure { get; }
        public int SupineHeartRate { get; }
        public BloodPressure MaximumBloodPressure { get; }
        public int MaximumHeartRate { get; }

        internal TreadmillExerciseStressTest(
            TreadmillProtocol protocol, 
            ITimeDuration time, 
            TreadmillExerciseStressTestResultClassification result, 
            BloodPressure supineBloodPressure, 
            int supineHeartRate, 
            BloodPressure maximumBloodPressure, 
            int maximumHeartRate)
        {
            Protocol = protocol;
            Time = time;
            Result = result;
            SupineBloodPressure = supineBloodPressure;
            SupineHeartRate = supineHeartRate;
            MaximumBloodPressure = maximumBloodPressure;
            MaximumHeartRate = maximumHeartRate;
        }

        public override string ToString() => 
            $"{Time} on {Protocol}, max BP {MaximumBloodPressure}, max HR {MaximumHeartRate}, result {Result} | " +
            $"supine BP {SupineBloodPressure} supine HR {SupineHeartRate}";
    }
}