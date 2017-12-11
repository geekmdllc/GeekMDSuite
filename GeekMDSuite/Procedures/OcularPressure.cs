namespace GeekMDSuite.Procedures
{
    public class OcularPressure
    {
        public OcularPressure(int left, int right)
        {
            Left = left;
            Right = right;
        }

        public int Left { get; }
        public int Right { get; }
    }
}