namespace GeekMDSuite.Procedures
{
    public class SitAndReach : IMuscularStrengthTest
    {
        private SitAndReach(double centimeters)
        {
            Value = centimeters;
        }

        public double Value { get; }
        public MuscularStrengthTest Type => MuscularStrengthTest.SitAndReach;

        public static SitAndReach Build(double centimeters) => new SitAndReach(centimeters);

        public override string ToString() => $"{Value} cm";
    }
}