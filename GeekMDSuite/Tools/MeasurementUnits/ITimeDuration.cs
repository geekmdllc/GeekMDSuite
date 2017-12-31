namespace GeekMDSuite.Tools.MeasurementUnits
{
    public interface ITimeDuration
    {
        double Minutes { get; set; }
        double Seconds { get; set; }
        double TotalSeconds { get; }
        double FractionalMinutes { get; }
    }
}