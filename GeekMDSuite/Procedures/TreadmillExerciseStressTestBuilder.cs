using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Procedures
{
    public class TreadmillExerciseStressTestBuilder
    {
        private TreadmillProtocol _protocol = TreadmillProtocol.Bruce;
        private TimeDuration _time;
        private TreadmillExerciseStressTestResultClassification _result;
        private BloodPressure _supineBloodPressure;
        private int _supineHeartRate;
        private BloodPressure _maximumBloodPressure;
        private int _maximumHeartRate;

        public TreadmillExerciseStressTestBuilder SetProtocol(TreadmillProtocol protocol = TreadmillProtocol.Bruce)
        {
            _protocol = protocol;
            return this;
        }

        public TreadmillExerciseStressTestBuilder SetTime(double minutes, double seconds)
        {
            _time = TimeDuration.Create(minutes, seconds);
            return this;
        }
        
        public TreadmillExerciseStressTestBuilder SetTime(TreadmillExerciseStressTestResultClassification result)
        {
            _result = result;
            return this;
        }
        
        public TreadmillExerciseStressTestBuilder SetSupineBloodPressure(int systolic, int diastolic)
        {
            _supineBloodPressure = BloodPressure.Build(systolic, diastolic);
            return this;
        }
        
        public TreadmillExerciseStressTestBuilder SetSupineHeartRate(int heartRate)
        {
            _supineHeartRate = heartRate;
            return this;
        }
        
        public TreadmillExerciseStressTestBuilder SetMaximumBloodPressure(int systolic, int diastolic)
        {
            _maximumBloodPressure = BloodPressure.Build(systolic, diastolic);
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