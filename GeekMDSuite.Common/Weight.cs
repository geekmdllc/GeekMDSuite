namespace GeekMDSuite.Common
{
    public class Weight
    {
        public double Pounds { get; set; }
        public double Kilograms => Pounds / 2.2;
    }
}