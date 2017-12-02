namespace GeekMDSuite
{
    public class BodyCompositionExpanded : BodyComposition, IBodyCompositionExpanded
    {

        public BodyCompositionExpanded(
            IBodyComposition bodyComposition, 
            double visceralFat, 
            double percentBodyFat) : base(
                bodyComposition.Height, 
                bodyComposition.Waist, 
                bodyComposition.Hips, 
                bodyComposition.Weight)
        {
            VisceralFat = visceralFat;
            PercentBodyFat = percentBodyFat;
        }

        public double VisceralFat { get; }

        public double PercentBodyFat { get; }
    }
}