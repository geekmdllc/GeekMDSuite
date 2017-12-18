namespace GeekMDSuite.Procedures
{
    public class Situps : IMuscularStrengthTest
    {
        private Situps(int count)
        {
            Value = count;
        }

        public double Value { get; }
        public MuscularStrengthTest Type => MuscularStrengthTest.Situps;

        public static Situps Build(int count) => new Situps(count);

        public override string ToString() => $"{Value} situps";
    }
}