using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite
{
    public interface IVitalSigns
    {
        BloodPressure BloodPressure { get; set; }
        int OxygenSaturation { get; set; }
        int PulseRate { get; set; }
        Temperature Temperature { get; set; }
    }
}