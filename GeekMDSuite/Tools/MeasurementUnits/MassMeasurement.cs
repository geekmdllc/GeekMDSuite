using GeekMDSuite.Tools.MeasurementUnits;
using GeekMDSuite.Tools.MeasurementUnits.Conversion;

namespace GeekMDSuite.Tools
{
    public class MassMeasurement : IMassMeasurement
    {
        public MassMeasurement(double pounds)
        {
            Pounds = pounds;
        }

        public double Pounds { get; }

        public double Kilograms => MassConversion.LbsToKilograms(Pounds);

        public double Grams => MassConversion.KilogramsToGrams(Kilograms);
    }
}