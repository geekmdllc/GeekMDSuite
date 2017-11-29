namespace GeekMDSuite
{
    public class AdvancedBodyComposition : BodyComposition, IAdvancedBodyComposition
    {
        public AdvancedBodyComposition(ILengthMeasurement height, 
            ILengthMeasurement waist, 
            ILengthMeasurement hips, 
            IMassMeasurement weight, 
            double visceralFat, 
            double percentBodyFat) 
            : base(height, waist, hips, weight)
        {
            VisceralFat = visceralFat;
            PercentBodyFat = percentBodyFat;
        }

        public double VisceralFat { get; }
        public double PercentBodyFat { get; }
    }

    public interface IAdvancedBodyComposition : IBodyComposition
    {
        double VisceralFat { get; }
        double PercentBodyFat { get; }
    }
}