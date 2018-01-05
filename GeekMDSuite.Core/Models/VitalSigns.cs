using GeekMDSuite.Core.Tools.MeasurementUnits;

namespace GeekMDSuite.Core.Models
{
    public class VitalSigns
    {

        private VitalSigns(BloodPressure bloodPressure, Temperature temperature, int oxygenSaturation, int pulseRate) : this()
        {
            BloodPressure = bloodPressure;
            Temperature = temperature;
            OxygenSaturation = oxygenSaturation;
            PulseRate = pulseRate;
        }

        protected internal VitalSigns()
        {
            BloodPressure = new BloodPressure();
            Temperature = new Temperature();
        }

        public BloodPressure BloodPressure { get; set; }

        public int OxygenSaturation { get; set; }

        public int PulseRate { get; set; }

        public Temperature Temperature { get; set; }

        public override string ToString()
        {
            return string.Format($"{BloodPressure} {Temperature} {OxygenSaturation}% {PulseRate} bpm");
        }
        
        
        internal static VitalSigns Build(BloodPressure bloodPressure, Temperature temperature, int oxygenSaturation,
            int pulseRate) => new VitalSigns(bloodPressure, temperature, oxygenSaturation, pulseRate);
    }
}