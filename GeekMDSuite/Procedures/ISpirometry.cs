namespace GeekMDSuite.Procedures
{
    public interface ISpirometry
    {
        double ForcedExpiratoryVolume1Second { get; }
        double ForcedVitalCapacity { get; }
        double PeakExpiratoryFlow { get; }
        double ForcedExpiratoryFlow25To75 { get; }
        double ForcedExpiratoryTime { get; }
        double ForcedExpiratoryVolume1SecondToForcedVitalCapacityRatio { get; }
    }
}