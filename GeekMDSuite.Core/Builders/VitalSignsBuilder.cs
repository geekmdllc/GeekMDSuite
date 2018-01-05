using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Core.Tools.MeasurementUnits;

namespace GeekMDSuite.Core.Builders
{
    public class VitalSignsBuilder : Builder<VitalSignsBuilder, VitalSigns>
    {
        public override VitalSigns Build()
        {
            ValidatePreBuildState();
            return BuildWithoutModelValidation();
        }

        public override VitalSigns BuildWithoutModelValidation()
        {
            return new VitalSigns()
            {
                BloodPressure = _bloodPressure,
                OxygenSaturation = _oxygenSaturation,
                PulseRate = _pulseRate,
                Temperature = _temperature
            };
        }

        public VitalSignsBuilder SetBloodPressure(int systolic, int diastolic, bool endOrganDamage)
        {
            _bloodPressure = BloodPressure.Build(systolic, diastolic, endOrganDamage);
            return this;
        }

        public VitalSignsBuilder SetTemperature(double temperatureFarenheight)
        {
            _temperature = Temperature.Create(temperatureFarenheight);
            return this;
        }
        
        public VitalSignsBuilder SetOxygenSaturation(int oxygenSaturation)
        {
            _oxygenSaturation = oxygenSaturation;
            return this;
        }
        public VitalSignsBuilder SetPulseRate(int pulseRate)
        {
            _pulseRate = pulseRate;
            return this;
        }
        
        private BloodPressure _bloodPressure;
        private Temperature _temperature;
        private int _oxygenSaturation;
        private int _pulseRate;
        
        private void ValidatePreBuildState()
        {
            var message = string.Empty;
            if (_bloodPressure == null) message += $"{nameof(SetBloodPressure)} ";
            if (_temperature == null) message += $"{nameof(SetTemperature)} ";
            if (_oxygenSaturation == default(int)) message += $"{nameof(SetOxygenSaturation)} ";
            if (_pulseRate == default(int)) message += $"{nameof(SetPulseRate)} ";
            if (!string.IsNullOrEmpty(message)) throw new MissingMethodException(message + " should be set");
        }

    }
}