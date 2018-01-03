namespace GeekMDSuite.Core.Procedures
{
    public class Pushups : MuscularStrengthTest
    {
        public static Pushups Build(int count) => new Pushups(count);

        protected Pushups()
        {
            Type = StrengthTest.Pushups;
        }

        private Pushups(int count) : this()
        {
            Value = count;
        }

    }
}