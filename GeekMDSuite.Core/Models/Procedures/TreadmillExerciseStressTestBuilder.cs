﻿using System;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Tools.MeasurementUnits;

namespace GeekMDSuite.Core.Models.Procedures
{
    public class TreadmillExerciseStressTestBuilder : Builder<TreadmillExerciseStressTestBuilder, TreadmillExerciseStressTest>
    {
        public override TreadmillExerciseStressTest Build()
        {
            ValidatePreBuildState();
            return BuildWithoutModelValidation();
        }

        public override TreadmillExerciseStressTest BuildWithoutModelValidation()
        {
            return new TreadmillExerciseStressTest()
            {
                Time = _time,
                MaximumBloodPressure =  _maximumBloodPressure,
                MaximumHeartRate = _maximumHeartRate,
                Protocol = _protocol,
                Result = _result,
                SupineBloodPressure = _supineBloodPressure,
                SupineHeartRate = _supineHeartRate
            };
        }

        public TreadmillExerciseStressTestBuilder SetProtocol(TreadmillProtocol protocol = TreadmillProtocol.Bruce)
        {
            _protocol = protocol;
            return this;
        }

        public TreadmillExerciseStressTestBuilder SetTime(double minutes, double seconds)
        {
            _time = TimeDuration.Build(minutes, seconds);
            return this;
        }
        
        public TreadmillExerciseStressTestBuilder SetResult(TmstResult result)
        {
            _resultIsSet = true;
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
        
        private TreadmillProtocol _protocol = TreadmillProtocol.Bruce;
        private TimeDuration _time;
        private TmstResult _result;
        private BloodPressure _supineBloodPressure;
        private int _supineHeartRate;
        private BloodPressure _maximumBloodPressure;
        private int _maximumHeartRate;
        private bool _resultIsSet;
        
        
        private void ValidatePreBuildState()
        {
            var message = string.Empty;
            if (_time == null) message += $"{nameof(SetTime)} ";
            if (!_resultIsSet) message += $"{nameof(SetResult)} ";
            if (_supineBloodPressure == null) message += $"{nameof(SetSupineBloodPressure)} ";
            if (_supineHeartRate == default(int)) message += $"{nameof(SetSupineHeartRate)} ";
            if (_maximumBloodPressure == null) message += $"{nameof(SetMaximumBloodPressure)} ";
            if (_maximumHeartRate == default(int)) message += $"{nameof(SetMaximumHeartRate)} ";
            if (!string.IsNullOrEmpty(message)) throw new MissingMethodException(message + " should be set.");
        }


    }
}