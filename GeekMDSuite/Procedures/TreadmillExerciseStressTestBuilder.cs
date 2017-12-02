using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Procedures
{
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