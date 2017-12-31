namespace GeekMDSuite.Procedures
{
    public class Pushups : IMuscularStrengthTest
    {
        protected internal Pushups() {}

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