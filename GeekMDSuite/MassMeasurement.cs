namespace GeekMDSuite
{
    public abstract class MassMeasurement : IMassMeasurement
    {
        public MassMeasurement(double pounds)
        {
            Pounds = pounds;
        }

        public double Pounds { get; }

        public double Kilograms => UnitConversion.LbsToKilograms(Pounds);

        public double Grams => UnitConversion.KilogramsToGrams(Kilograms);
    }
}