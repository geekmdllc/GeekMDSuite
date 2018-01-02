using GeekMDSuite.Core.Tools.MeasurementUnits;
using GeekMDSuite.Core.Tools.MeasurementUnits.Conversion;

namespace GeekMDSuite.Core.Procedures
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