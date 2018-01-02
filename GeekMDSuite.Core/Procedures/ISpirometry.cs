namespace GeekMDSuite.Core.Procedures
{
    public interface ISpirometry
    {
        double ForcedExpiratoryVolume1Second { get; set; }
        double ForcedVitalCapacity { get; set; }
        double PeakExpiratoryFlow { get; set; }
        double ForcedExpiratoryFlow25To75 { get; set; }
        double ForcedExpiratoryTime { get; set; }
        double ForcedExpiratoryVolume1SecondToForcedVitalCapacityRatio { get; }
    }
}