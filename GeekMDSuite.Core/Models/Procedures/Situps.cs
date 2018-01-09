namespace GeekMDSuite.Core.Models.Procedures
{
    public class Situps : MuscularStrengthTest
    {
        protected Situps()
        {
            Type = StrengthTest.Situps;
        }

        private Situps(int count) : this()
        {
            Value = count;
        }

        public static Situps Build(int count)
        {
            return new Situps(count);
        }

        public override string ToString()
        {
            return $"{Value} situps";
        }
    }
}