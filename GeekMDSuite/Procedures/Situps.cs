namespace GeekMDSuite.Procedures
{
    public class Situps : IMuscularStrengthTest
    {
        public Situps(int count)
        {
            Value = count;
        }

        public double Value { get; }
        public MuscularStrengthTest Type => MuscularStrengthTest.Situps;
    }
}