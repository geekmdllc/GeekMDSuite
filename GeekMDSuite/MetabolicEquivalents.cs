using GeekMDSuite.Tools.Fitness;
using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite
{
    public static class MetabolicEquivalents
    {
        public static double FromVo2Max(Vo2Max vo2Max)
        {
            return vo2Max.Value / 3.5;
        }
        
        public static double FromTreadmillStressTest(TreadmillProtocol protocol, TimeDuration timeDuration, IPatient patient)
        {
            return FromVo2Max(CalculateVo2Max.FromTreadmillStressTest(protocol, timeDuration, patient));
        }
    }

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

    public class TreadmillExerciseStressTestBuilder
    {
        private TreadmillProtocol _protocol;
        private TimeDuration _time;
        private TreadmillExerciseStressTestResultClassification _result;
        private BloodPressure _supineBloodPressure;
        private int _supineHeartRate;
        private BloodPressure _maximumBloodPressure;
        private int _maximumHeartRate;

        public TreadmillExerciseStressTestBuilder SetProtocol(TreadmillProtocol protocol)
        {
            _protocol = protocol;
            return this;
        }

        public TreadmillExerciseStressTestBuilder SetTime(TimeDuration time)
        {
            _time = time;
            return this;
        }
        
        public TreadmillExerciseStressTestBuilder SetTime(TreadmillExerciseStressTestResultClassification result)
        {
            _result = result;
            return this;
        }
        
        public TreadmillExerciseStressTestBuilder SetSupineBloodPressure(BloodPressure bloodPressure)
        {
            _supineBloodPressure = bloodPressure;
            return this;
        }
        
        public TreadmillExerciseStressTestBuilder SetSupineHeartRate(int heartRate)
        {
            _supineHeartRate = heartRate;
            return this;
        }
        
        public TreadmillExerciseStressTestBuilder SetMaximumBloodPressure(BloodPressure bloodPressure)
        {
            _maximumBloodPressure = bloodPressure;
            return this;
        }
        
        public TreadmillExerciseStressTestBuilder SetMaximumHeartRate(int heartRate)
        {
            _maximumHeartRate = heartRate;
            return this;
        }

        public TreadmillExerciseStressTest Build()
        {
            return new TreadmillExerciseStressTest(_protocol, _time, _result, _supineBloodPressure, _supineHeartRate, 
                _maximumBloodPressure, _maximumHeartRate);
        }
    }
}