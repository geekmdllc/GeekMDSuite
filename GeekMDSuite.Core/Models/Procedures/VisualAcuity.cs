namespace GeekMDSuite.Core.Models.Procedures
{
    public class VisualAcuity
    {
        private VisualAcuity(int distance, int near, int both) : this()
        {
            Distance = distance;
            Near = near;
            Both = both;
        }

        protected VisualAcuity()
        {
        }

        public int Distance { get; set; }
        public int Near { get; set; }
        public int Both { get; set; }

        public static VisualAcuity Build(int distance, int near, int both)
        {
            return new VisualAcuity(distance, near, both);
        }

        public override string ToString()
        {
            return $"Distance: {Distance}/20 Near: {Near}/20 Both: {Both}/20";
        }
    }
}