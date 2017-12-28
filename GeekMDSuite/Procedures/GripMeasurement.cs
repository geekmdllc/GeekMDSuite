using GeekMDSuite.Tools.MeasurementUnits;
using GeekMDSuite.Tools.MeasurementUnits.Conversion;

namespace GeekMDSuite.Procedures
{
    public class GripMeasurement : IMassMeasurement
    {
        private GripMeasurement(double pounds)
        {
            Pounds = pounds;
            Kilograms = MassConversion.LbsToKilograms(Pounds);
            Grams = MassConversion.KilogramsToGrams(Kilograms);
        }

        public double Pounds { get; }
        public double Kilograms { get; }
        public double Grams { get; }

        public static GripMeasurement Build(double pounds) => new GripMeasurement(pounds);

        public override string ToString() => $"{Pounds} lbs";
    }
}