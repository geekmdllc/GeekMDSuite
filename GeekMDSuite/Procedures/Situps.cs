namespace GeekMDSuite.Procedures
{
    public class Situps : IMuscularStrengthTest
    {
        public Situps(int count)
        {
            Count = count;
        }

        public int Count { get; }
        public MuscularStrengthTest Type => MuscularStrengthTest.Situps;
    }
}