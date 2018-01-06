namespace GeekMDSuite.Core.Models.Procedures
{
    public class PeripheralVision
    {
        private PeripheralVision(int left, int right) : this()
        {
            Left = left;
            Right = right;
        }

        protected PeripheralVision()
        {
        }

        public int Left { get; set; }
        public int Right { get; set; }

        public static PeripheralVision Build(int leftDegrees, int rightDegrees)
        {
            return new PeripheralVision(leftDegrees, rightDegrees);
        }

        public override string ToString()
        {
            return $"Left: {Left} degrees, Right: {Right} degrees";
        }
    }
}