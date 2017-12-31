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

        protected internal BodyCompositionExpanded()
        {
            
        }

        public double VisceralFat { get; set; }

        public double PercentBodyFat { get; set; }
        
        internal static BodyCompositionExpanded Build(IBodyComposition bodyComposition, double visceralFat, double percentBodyFat) =>
            new BodyCompositionExpanded(bodyComposition, visceralFat, percentBodyFat);

        public override string ToString() => 
            base.ToString() + $" Visceral: {VisceralFat} cm^2 Body Fat: {PercentBodyFat} %";
    }
}