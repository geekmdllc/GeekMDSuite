namespace GeekMDSuite.Core.Models.Procedures
{
    public class OccularPressure
    {
        protected OccularPressure()
        {
        }

        private OccularPressure(int leftMmHg, int rightMmHg) : this()
        {
            Left = leftMmHg;
            Right = rightMmHg;
        }

        public int Left { get; set; }
        public int Right { get; set; }

        public static OccularPressure Build(int leftMmHg, int rightMmHg)
        {
            return new OccularPressure(leftMmHg, rightMmHg);
        }

        public override string ToString()
        {
            return $"Left: {Left} mmHg, Right: {Right} mmHg";
        }
    }
}