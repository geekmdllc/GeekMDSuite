namespace GeekMDSuite.Core.Procedures
{
    public class GripStrength 
    {
        public GripMeasurement Left { get; set; }
        public GripMeasurement Right { get; set; }

        public static GripStrength Build(double leftPounds, double rightPounds) => new GripStrength(leftPounds, rightPounds);

        public override string ToString() => $"Left: {Left} Right: {Right}";
        
        protected GripStrength()
        {
            Left = new GripMeasurement();
            Right = new GripMeasurement();
        }
        
        private GripStrength(GripMeasurement left, GripMeasurement right) : this()
        {
            Left = left;
            Right = right;
        }

        private GripStrength(double left, double right): this(GripMeasurement.Build(left), GripMeasurement.Build(right))
        {  }


    }
}