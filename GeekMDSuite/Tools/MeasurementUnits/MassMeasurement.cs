using GeekMDSuite.Tools.Math;
using GeekMDSuite.Tools.MeasurementUnits;

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