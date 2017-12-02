using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite
{
    public class TreadmillExerciseStressTest
    {
        public TreadmillProtocol Protocol { get; }
        public TimeDuration Time { get; }
        public TreadmillExerciseStressTestResultClassification Result { get; }
        public BloodPressure SupineBloodPressure { get; }
        public int SupineHeartRate { get; }
        public BloodPressure MaximumBloodPressure { get; }
        public int MaximumHeartRate { get; }

        internal TreadmillExerciseStressTest(
            TreadmillProtocol protocol, 
            TimeDuration time, 
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
    }
}