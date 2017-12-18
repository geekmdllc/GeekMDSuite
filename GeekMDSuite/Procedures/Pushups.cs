namespace GeekMDSuite.Procedures
{
    public class Pushups : IMuscularStrengthTest
    {
        private Pushups(int count)
        {
            Value = count;
        }

        public double Value { get; }
        public MuscularStrengthTest Type => MuscularStrengthTest.Pushups;

        public static Pushups Build(int count) => new Pushups(count);

        public override string ToString() => $"{Value} pushups";
    }
}