using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite
{
    public class VitalSigns : IVitalSigns
    {

        private VitalSigns(BloodPressure bloodPressure, Temperature temperature, int oxygenSaturation, int pulseRate)
        {
            BloodPressure = bloodPressure;
            Temperature = temperature;
            OxygenSaturation = oxygenSaturation;
            PulseRate = pulseRate;
        }

        public BloodPressure BloodPressure { get; }

        public int OxygenSaturation { get; }

        public int PulseRate { get; }

        public Temperature Temperature { get; }

        public override string ToString()
        {
            return string.Format($"{BloodPressure} {Temperature} {OxygenSaturation}% {PulseRate} bpm");
        }
        
        
        internal static VitalSigns Build(BloodPressure bloodPressure, Temperature temperature, int oxygenSaturation,
            int pulseRate) => new VitalSigns(bloodPressure, temperature, oxygenSaturation, pulseRate);
    }
}