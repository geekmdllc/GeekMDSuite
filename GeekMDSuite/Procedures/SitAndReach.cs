namespace GeekMDSuite.Procedures
{
    public class SitAndReach : IMuscularStrengthTest
    {
        public SitAndReach(double centimeters)
        {
            Value = centimeters;
        }

        public double Value { get; }
        public MuscularStrengthTest Type => MuscularStrengthTest.SitAndReach;
    }
}