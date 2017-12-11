namespace GeekMDSuite.Procedures
{
    public class PeripheralVision
    {
        public PeripheralVision(int left, int right)
        {
            Left = left;
            Right = right;
        }

        public int Left { get; }
        public int Right { get; }
    }
}