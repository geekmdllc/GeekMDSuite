namespace GeekMDSuite.Common
{
    public class Weight
    {
        public Weight(double pounds)
        {
            Pounds = pounds;
        }

        public double Pounds { get; set; }
        public double Kilograms => Pounds / 2.2;
    }
}