using GeekMDSuite.Utilities.MeasurementUnits.Conversion;

namespace GeekMDSuite.Utilities.MeasurementUnits
{
    public class MassMeasurement
    {
        protected MassMeasurement(double pounds)
        {
            Pounds = pounds;
        }

        protected MassMeasurement()
        {
        }

        public double Pounds { get; set; }

        public double Kilograms => MassConversion.LbsToKilograms(Pounds);

        public double Grams => MassConversion.KilogramsToGrams(Kilograms);

        public override string ToString()
        {
            return $"{Pounds} lbs";
        }
    }
}