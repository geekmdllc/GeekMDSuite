using GeekMDSuite.Core.Tools.MeasurementUnits;

namespace GeekMDSuite.Core
{
    public interface IBodyComposition
    {
        Height Height { get; set; }
        Waist Waist { get; set; }
        Hips Hips { get; set; }
        Weight Weight { get; set; }
    }
}