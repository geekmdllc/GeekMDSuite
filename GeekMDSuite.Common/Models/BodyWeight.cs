using GeekMDSuite.Common.Tools;
    
namespace GeekMDSuite.Common.Models
{
    public class BodyWeight : IMassMeasurement
    {
        private double _pounds;

        public BodyWeight(double pounds)
        {
            _pounds = pounds;
        }

        public double Pounds => _pounds;

        public double Kilograms => UnitConversion.LbsToKilograms(_pounds);

        public double Grams => UnitConversion.KilogramsToGrams(Kilograms);
    }
}