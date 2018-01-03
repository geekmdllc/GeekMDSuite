namespace GeekMDSuite.Core.Procedures
{
    public class SitAndReach : MuscularStrengthTest
    {
        public static SitAndReach Build(double centimeters) => new SitAndReach(centimeters);

        public override string ToString() => $"{Value} cm";

        protected SitAndReach()
        {
            Type = StrengthTest.SitAndReach;
        }

        private SitAndReach(double centimeters) : this()
        {
            Value = centimeters;
        }
    }
}