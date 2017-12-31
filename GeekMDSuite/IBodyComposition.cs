using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite
{
    public interface IBodyComposition
    {
        ILengthMeasurement Height { get; set; }
        ILengthMeasurement Waist { get; set; }
        ILengthMeasurement Hips { get; set; }
        IMassMeasurement Weight { get; set; }
    }
}