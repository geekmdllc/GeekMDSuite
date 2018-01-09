namespace GeekMDSuite.Core.Models.Procedures
{
    public class Pushups : MuscularStrengthTest
    {
        protected Pushups()
        {
            Type = StrengthTest.Pushups;
        }

        private Pushups(int count) : this()
        {
            Value = count;
        }

        public static Pushups Build(int count)
        {
            return new Pushups(count);
        }
    }
}