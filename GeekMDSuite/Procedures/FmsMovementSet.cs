namespace GeekMDSuite.Procedures
{
    public class FmsMovementSet
    {
        internal FmsMovementSet(FmsMovementData left, FmsMovementData right)
        {
            Left = left;
            Right = right;
        }

        public FmsMovementData Left { get; }
        public FmsMovementData Right { get; }

        public int Score => Left.Score < Right.Score
            ? Right.Score
            : Left.Score;

        public override string ToString() => $"{Left}\n{Right}";
    }
}