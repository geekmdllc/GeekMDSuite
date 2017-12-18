namespace GeekMDSuite.Procedures
{
    public class VisualAcuity
    {
        private VisualAcuity (int distance, int near, int both) 
        {
            Distance = distance;
            Near = near;
            Both = both;
        }

        public int Distance { get; }
        public int Near { get; }
        public int Both { get; }

        public static VisualAcuity Build(int distance, int near, int both) => new VisualAcuity(distance, near, both);

        public override string ToString() => $"Distance: {Distance}/20 Near: {Near}/20 Both: {Both}/20";
    }
}