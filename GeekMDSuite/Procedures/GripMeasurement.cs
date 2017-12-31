using GeekMDSuite.Tools.MeasurementUnits;
using GeekMDSuite.Tools.MeasurementUnits.Conversion;

namespace GeekMDSuite.Procedures
{
    public class GripMeasurement : IMassMeasurement
    {
        private GripMeasurement(double pounds)
        {
            Pounds = pounds;
        }

        public double Pounds { get; set; }
        public double Kilograms => MassConversion.LbsToKilograms(Pounds);
        public double Grams => MassConversion.KilogramsToGrams(Kilograms);

        public static GripMeasurement Build(double pounds) => new GripMeasurement(pounds);

        public override string ToString() => $"{Pounds} lbs";

        public GripMeasurement()
        {
            
        }
    }
}