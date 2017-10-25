namespace GeekMDSuite.Interpretation.Tools
{
    public class IntegerRange
    {
        public int Upper { get;  }
        public int Lower { get;  }

        public IntegerRange(int lower, int upper)
        {
            Lower = lower;
            Upper = upper;
        }
        
        public bool Contains(int z) => (z >= Lower && z < Upper);
    }
}