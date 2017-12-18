namespace GeekMDSuite.Procedures
{
    public class PeripheralVision
    {
        private PeripheralVision(int left, int right)
        {
            Left = left;
            Right = right;
        }

        public int Left { get; }
        public int Right { get; }

        public static PeripheralVision Build(int leftDegrees, int rightDegrees) 
            => new PeripheralVision(leftDegrees, rightDegrees);

        public override string ToString() => $"Left: {Left} degrees, Right: {Right} degrees";
    }
}