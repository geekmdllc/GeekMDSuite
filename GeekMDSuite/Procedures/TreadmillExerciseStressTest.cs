using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Procedures
{
    public class TreadmillExerciseStressTest : ITreadmillExerciseStressTest
    {
        public TreadmillProtocol Protocol { get; set; }
        public ITimeDuration Time { get; set; }
        public TmstResult Result { get; set; }
        public BloodPressure SupineBloodPressure { get; set; }
        public int SupineHeartRate { get; set; }
        public BloodPressure MaximumBloodPressure { get; set; }
        public int MaximumHeartRate { get; set; }

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

        protected internal TreadmillExerciseStressTest()
        {
            Time = new TimeDuration();
            SupineBloodPressure = new BloodPressure();
            MaximumBloodPressure = new BloodPressure();
        }
        
        private TreadmillExerciseStressTest(
            TreadmillProtocol protocol, 
            ITimeDuration time, 
            TmstResult result, 
            BloodPressure supineBloodPressure, 
            int supineHeartRate, 
            BloodPressure maximumBloodPressure, 
            int maximumHeartRate) : this()
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