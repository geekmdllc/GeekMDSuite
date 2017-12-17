namespace GeekMDSuite
{
    public class BodyCompositionExpanded : BodyComposition, IBodyCompositionExpanded
    {
        private BodyCompositionExpanded(
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
        
        internal static BodyCompositionExpanded Build(IBodyComposition bodyComposition, double visceralFat, double percentBodyFat) =>
            new BodyCompositionExpanded(bodyComposition, visceralFat, percentBodyFat);

        public override string ToString() => 
            base.ToString() + $" Visceral: {VisceralFat} cm^2 Body Fat: {PercentBodyFat} %";
    }
}