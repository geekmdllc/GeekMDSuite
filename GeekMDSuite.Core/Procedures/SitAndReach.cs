namespace GeekMDSuite.Core.Procedures
{
    public class SitAndReach : IMuscularStrengthTest
    {
        public static SitAndReach Build(double centimeters) => new SitAndReach(centimeters);
        private SitAndReach(double centimeters) : this()
        {
            Value = centimeters;
        }

        protected SitAndReach()
        {
            
        }

        public double Value { get; set; }
        public MuscularStrengthTest Type => MuscularStrengthTest.SitAndReach;

        public override string ToString() => $"{Value} cm";
    }
}