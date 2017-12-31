namespace GeekMDSuite.Procedures
{
    public class Situps : IMuscularStrengthTest
    {
        public static Situps Build(int count) => new Situps(count);

        public double Value { get; set; }
        public MuscularStrengthTest Type => MuscularStrengthTest.Situps;

        public override string ToString() => $"{Value} situps";

        protected Situps()
        {
            
        }
        private Situps(int count) : this()
        {
            Value = count;
        }
    }
}