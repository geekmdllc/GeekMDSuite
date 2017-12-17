namespace GeekMDSuite.Procedures
{
    public class OcularPressure
    {
        private OcularPressure(int leftMmHg, int rightMmHg)
        {
            Left = leftMmHg;
            Right = rightMmHg;
        }

        public int Left { get; }
        public int Right { get; }

        public static OcularPressure Build(int leftMmHg, int rightMmHg) => new OcularPressure(leftMmHg, rightMmHg);
    }
}