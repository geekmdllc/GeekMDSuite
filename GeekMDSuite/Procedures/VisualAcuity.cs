using GeekMDSuite.Services.Interpretation;
using MathNet.Numerics;

namespace GeekMDSuite.Procedures
{
    public class VisualAcuity
    {
        public VisualAcuity (int distance, int near, int both) 
        {
            Distance = distance;
            Near = near;
            Both = both;
        }

        public int Distance { get; }
        public int Near { get; }
        public int Both { get; }
    }
}