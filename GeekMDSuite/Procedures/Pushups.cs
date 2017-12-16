namespace GeekMDSuite.Procedures
{
    public class Pushups : IMuscularStrengthTest
    {
        public Pushups(int count)
        {
            Value = count;
        }

        public double Value { get; }
        public MuscularStrengthTest Type => MuscularStrengthTest.Pushups;
    }
}