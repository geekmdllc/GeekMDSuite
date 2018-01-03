namespace GeekMDSuite.Core.Procedures
{
    public abstract class MuscularStrengthTest
    {
        public double Value { get; set; }
        public StrengthTest Type { get; set; }

        public override string ToString() => $"{Value} {Type.ToString().ToLower()}";
        
        protected MuscularStrengthTest() {}
    }
}