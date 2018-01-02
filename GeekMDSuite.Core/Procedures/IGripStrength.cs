namespace GeekMDSuite.Core.Procedures
{
    public interface IGripStrength
    {
        GripMeasurement Left { get; set; }
        GripMeasurement Right { get; set; }
    }
}