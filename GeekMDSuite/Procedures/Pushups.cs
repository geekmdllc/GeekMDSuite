namespace GeekMDSuite.Procedures
{
    public class Pushups : IMuscularStrengthTest
    {
        public Pushups(int count)
        {
            Count = count;
        }

        public int Count { get; }
        public MuscularStrengthTest Type => MuscularStrengthTest.Pushups;
    }
}