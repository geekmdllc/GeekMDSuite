namespace GeekMDSuite.Core.Procedures
{
    public class VisualAcuity 
    {
        public static VisualAcuity Build(int distance, int near, int both) => new VisualAcuity(distance, near, both);

        public int Distance { get; set; }
        public int Near { get; set; }
        public int Both { get; set; }

        public override string ToString() => $"Distance: {Distance}/20 Near: {Near}/20 Both: {Both}/20";
        
        private VisualAcuity (int distance, int near, int both) : this()
        {
            Distance = distance;
            Near = near;
            Both = both;
        }

        protected VisualAcuity()
        {
            
        }
    }
}