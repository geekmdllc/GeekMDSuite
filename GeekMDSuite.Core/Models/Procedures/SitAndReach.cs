namespace GeekMDSuite.Core.Models.Procedures
{
    public class SitAndReach : MuscularStrengthTest
    {
        protected SitAndReach()
        {
            Type = StrengthTest.SitAndReach;
        }

        private SitAndReach(double centimeters) : this()
        {
            Value = centimeters;
        }

        public static SitAndReach Build(double centimeters)
        {
            return new SitAndReach(centimeters);
        }

        public override string ToString()
        {
            return $"{Value} cm";
        }
    }
}