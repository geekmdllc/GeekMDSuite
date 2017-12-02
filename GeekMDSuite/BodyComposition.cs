using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite
{
    public class BodyComposition : IBodyComposition
    {
        public BodyComposition(ILengthMeasurement height, 
            ILengthMeasurement waist, 
            ILengthMeasurement hips, 
            IMassMeasurement weight)
        {
            Height = height;
            Waist = waist;
            Hips = hips;
            Weight = weight;
        }
        public ILengthMeasurement Height { get; }
        public ILengthMeasurement Waist { get; }
        public ILengthMeasurement Hips { get; }
        public IMassMeasurement Weight { get; }
    }
}