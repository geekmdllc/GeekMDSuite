namespace GeekMDSuite.Core.Models.Procedures
{
    public class GripStrength
    {
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

        private GripStrength(double left, double right) : this(GripMeasurement.Build(left),
            GripMeasurement.Build(right))
        {
        }

        public GripMeasurement Left { get; set; }
        public GripMeasurement Right { get; set; }

        public static GripStrength Build(double leftPounds, double rightPounds)
        {
            return new GripStrength(leftPounds, rightPounds);
        }

        public override string ToString()
        {
            return $"Left: {Left} Right: {Right}";
        }
    }
}