namespace GeekMDSuite.Core.Models.Procedures
{
    public class Situps : MuscularStrengthTest
    {
        public static Situps Build(int count) => new Situps(count);

        public override string ToString() => $"{Value} situps";

        protected Situps()
        {
            Type = StrengthTest.Situps;
        }
        
        private Situps(int count) : this()
        {
            Value = count;
        }
    }
}