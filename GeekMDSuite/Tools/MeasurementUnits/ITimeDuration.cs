namespace GeekMDSuite.Tools.MeasurementUnits
{
    public interface ITimeDuration
    {
        int Minutes { get; }
        int Seconds { get; }
        double TotalSeconds { get; }
        double FractionalMinutes { get; }
    }
}