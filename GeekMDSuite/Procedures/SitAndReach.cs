using GeekMDSuite.Tools.MeasurementUnits;
using GeekMDSuite.Tools.MeasurementUnits.Conversion;

namespace GeekMDSuite.Procedures
{
    public class SitAndReach : IMuscularStrengthTestType
    {
        public SitAndReach(double centimeters)
        {
            Distance = LengthMeasurement.Create(LengthConversion.CentimetersToInches(centimeters));
        }

        public ILengthMeasurement Distance { get; }
        
        public MuscularStrengthTest Type => MuscularStrengthTest.SitAndReach;        
    }
}