namespace GeekMDSuite.Core.Procedures
{
    public class Pushups : IMuscularStrengthTest
    {
        protected Pushups() {}

        public static Pushups Build(int count) => new Pushups(count);
        
        public double Value { get; set; }
        public MuscularStrengthTest Type => MuscularStrengthTest.Pushups;
        
        public override string ToString() => $"{Value} pushups";
        
        private Pushups(int count) : this()
        {
            Value = count;
        }
    }
}