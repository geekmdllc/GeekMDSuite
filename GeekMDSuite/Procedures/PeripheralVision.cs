namespace GeekMDSuite.Procedures
{
    public class PeripheralVision
    {
        public static PeripheralVision Build(int leftDegrees, int rightDegrees) 
            => new PeripheralVision(leftDegrees, rightDegrees);

        public int Left { get; }
        public int Right { get; }

        public override string ToString() => $"Left: {Left} degrees, Right: {Right} degrees";
        
        private PeripheralVision(int left, int right)
        {
            Left = left;
            Right = right;
        }
    }
}