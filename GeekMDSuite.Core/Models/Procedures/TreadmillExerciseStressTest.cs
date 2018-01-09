using GeekMDSuite.Utilities.MeasurementUnits;

namespace GeekMDSuite.Core.Models.Procedures
{
    public class TreadmillExerciseStressTest
    {
        protected internal TreadmillExerciseStressTest()
        {
            Time = new TimeDuration();
            SupineBloodPressure = new BloodPressure();
            MaximumBloodPressure = new BloodPressure();
        }

        private TreadmillExerciseStressTest(
            TreadmillProtocol protocol,
            TimeDuration time,
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

        public TreadmillProtocol Protocol { get; set; }
        public TimeDuration Time { get; set; }
        public TmstResult Result { get; set; }
        public BloodPressure SupineBloodPressure { get; set; }
        public int SupineHeartRate { get; set; }
        public BloodPressure MaximumBloodPressure { get; set; }
        public int MaximumHeartRate { get; set; }

        internal static TreadmillExerciseStressTest Build(
            TreadmillProtocol protocol,
            TimeDuration time,
            TmstResult result,
            BloodPressure supineBloodPressure,
            int supineHeartRate,
            BloodPressure maximumBloodPressure,
            int maximumHeartRate)
        {
            return new TreadmillExerciseStressTest(protocol, time, result, supineBloodPressure, supineHeartRate,
                maximumBloodPressure, maximumHeartRate);
        }

        public override string ToString()
        {
            return
                $"{Time} on {Protocol}, max BP {MaximumBloodPressure}, max HR {MaximumHeartRate}, result {Result} | " +
                $"supine BP {SupineBloodPressure} supine HR {SupineHeartRate}";
        }
    }
}