using GeekMDSuite.Tools;
using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite
{
    public interface IVitalSigns
    {
        BloodPressureParameters BloodPressure { get; }
        int OxygenSaturation { get; }
        int PulseRate { get; }
        Temperature Temperature { get; }
    }
}