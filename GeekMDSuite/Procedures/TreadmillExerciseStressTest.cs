using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Procedures
{
    public class TreadmillExerciseStressTest : ITreadmillExerciseStressTest
    {
        public TreadmillProtocol Protocol { get; }
        public ITimeDuration Time { get; }
        public TmstResult Result { get; }
        public BloodPressure SupineBloodPressure { get; }
        public int SupineHeartRate { get; }
        public BloodPressure MaximumBloodPressure { get; }
        public int MaximumHeartRate { get; }

        internal static TreadmillExerciseStressTest Build(
            TreadmillProtocol protocol,
            ITimeDuration time,
            TmstResult result,
            BloodPressure supineBloodPressure,
            int supineHeartRate,
            BloodPressure maximumBloodPressure,
            int maximumHeartRate)
        {
            return new TreadmillExerciseStressTest(protocol, time, result, supineBloodPressure, supineHeartRate,
                maximumBloodPressure, maximumHeartRate);
        }

        
        private TreadmillExerciseStressTest(
            TreadmillProtocol protocol, 
            ITimeDuration time, 
            TmstResult result, 
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