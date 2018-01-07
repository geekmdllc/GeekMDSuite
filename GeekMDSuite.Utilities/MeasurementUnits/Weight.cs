namespace GeekMDSuite.Utilities.MeasurementUnits
{
    public class Weight : MassMeasurement
    {
        private Weight(double pounds) : base(pounds)
        {
        }

        public Weight()
        {
        }

        public static Weight Build(double pounds)
        {
            return new Weight(pounds);
        }
    }
}