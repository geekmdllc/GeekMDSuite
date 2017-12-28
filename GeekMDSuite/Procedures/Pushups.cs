namespace GeekMDSuite.Procedures
{
    public class Pushups : IMuscularStrengthTest
    {
        public static Pushups Build(int count) => new Pushups(count);
        
        public double Value { get; }
        public MuscularStrengthTest Type => MuscularStrengthTest.Pushups;
        
        public override string ToString() => $"{Value} pushups";
        
        private Pushups(int count)
        {
            Value = count;
        }
    }
}