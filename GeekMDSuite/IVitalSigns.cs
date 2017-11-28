namespace GeekMDSuite
{
    public interface IVitalSigns
    {
        BloodPressureParameters BloodPressure { get; }
        int OxygenSaturation { get; }
        int PulseRate { get; }
        double TemperatureFarenheit { get; }
        double TemperatureCelcius { get; }
    }
}