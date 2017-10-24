using System;

namespace GeekMDSuite.Interpretation.Tools
{
    public class Range
    {
        public int Upper { get; set; }
        public int Lower { get; set; }

        public Range(int lower, int upper)
        {
            Lower = lower;
            Upper = upper;
        }
        
        public bool IsInRange(int z) => (z >= Lower && z < Upper);
    }
}