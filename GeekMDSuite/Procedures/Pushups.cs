namespace GeekMDSuite.Procedures
{
    public class Pushups : IMuscularStrengthTest
    {
        public override string ToString() => $"{Value} pushups";
        
        public static Pushups Build(int count) => new Pushups(count);
        public double Value { get; }
        public MuscularStrengthTest Type => MuscularStrengthTest.Pushups;
        
        private Pushups(int count)
        {
            Value = count;
        }
    }
}