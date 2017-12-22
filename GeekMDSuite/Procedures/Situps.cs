namespace GeekMDSuite.Procedures
{
    public class Situps : IMuscularStrengthTest
    {
        public static Situps Build(int count) => new Situps(count);

        public double Value { get; }
        public MuscularStrengthTest Type => MuscularStrengthTest.Situps;

        public override string ToString() => $"{Value} situps";
        
        private Situps(int count)
        {
            Value = count;
        }
    }
}