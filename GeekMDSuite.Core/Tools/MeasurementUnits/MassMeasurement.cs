using GeekMDSuite.Core.Tools.MeasurementUnits.Conversion;

namespace GeekMDSuite.Core.Tools.MeasurementUnits
{
    public class MassMeasurement : IMassMeasurement
    {
        protected MassMeasurement(double pounds)
        {
            Pounds = pounds;
        }

        protected MassMeasurement()
        {
            
        }

        public double Pounds { get; set;  }

        public double Kilograms => MassConversion.LbsToKilograms(Pounds);

        public double Grams => MassConversion.KilogramsToGrams(Kilograms);

        public override string ToString() => $"{Pounds} lbs";
    }
}