namespace GeekMDSuite
{
    public interface IBodyComposition
    {
        ILengthMeasurement Height { get; }
        ILengthMeasurement Waist { get; }
        ILengthMeasurement Hips { get; }
        IMassMeasurement Weight { get; }
    }
}