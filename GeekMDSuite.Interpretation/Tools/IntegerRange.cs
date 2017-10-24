using System;

namespace GeekMDSuite.Interpretation.Tools
{
    public class IntegerRange
    {
        public int Upper { get; set; }
        public int Lower { get; set; }

        public IntegerRange(int lower, int upper)
        {
            Lower = lower;
            Upper = upper;
        }
        
        public bool Contains(int z) => (z >= Lower && z < Upper);
    }
}