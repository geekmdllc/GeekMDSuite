namespace GeekMDSuite
{
    public class BodyWeight : IMassMeasurement
    {
        public BodyWeight(double pounds)
        {
            Pounds = pounds;
        }

        public double Pounds { get; }

        public double Kilograms => UnitConversion.LbsToKilograms(Pounds);

        public double Grams => UnitConversion.KilogramsToGrams(Kilograms);
    }
}