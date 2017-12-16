using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite
{
    public class VitalSignsBuilder
    {
        private BloodPressure _bloodPressure;
        private Temperature _temperature;
        private int _oxygenSaturation;
        private int _pulseRate;

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

        public VitalSigns Build() => new VitalSigns(_bloodPressure, _temperature, _oxygenSaturation, _pulseRate);
    }
}