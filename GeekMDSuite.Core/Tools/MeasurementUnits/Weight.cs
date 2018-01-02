namespace GeekMDSuite.Core.Tools.MeasurementUnits
{
    public class Weight : MassMeasurement
    {
        private Weight(double pounds) : base(pounds)
        {
        }

        protected internal Weight()
        {
            
        }
        public static Weight Build(double pounds) => new Weight(pounds);
    }
}