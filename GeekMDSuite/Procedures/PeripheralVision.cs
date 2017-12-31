namespace GeekMDSuite.Procedures
{
    public class PeripheralVision : IPeripheralVision
    {
        public static PeripheralVision Build(int leftDegrees, int rightDegrees) 
            => new PeripheralVision(leftDegrees, rightDegrees);

        public int Left { get; set; }
        public int Right { get; set; }

        public override string ToString() => $"Left: {Left} degrees, Right: {Right} degrees";
        
        private PeripheralVision(int left, int right) : this()
        {
            Left = left;
            Right = right;
        }

        protected PeripheralVision() {} 
    }
}