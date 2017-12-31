namespace GeekMDSuite.Procedures
{
    public class GripStrength : IGripStrength
    {
        private GripStrength(GripMeasurement left, GripMeasurement right)
        {
            Left = left;
            Right = right;
        }

        private GripStrength(double left, double right) 
            : this(GripMeasurement.Build(left), GripMeasurement.Build(right))
        {  }

        public GripMeasurement Left { get; set; }
        public GripMeasurement Right { get; set; }

        public static GripStrength Build(double leftPounds, double rightPounds) => new GripStrength(leftPounds, rightPounds);

        public override string ToString() => $"Left: {Left} Right: {Right}";

        protected GripStrength()
        {
            Left = new GripMeasurement();
            Right = new GripMeasurement();
        }
    }
}