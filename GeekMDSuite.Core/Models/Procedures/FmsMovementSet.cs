namespace GeekMDSuite.Core.Models.Procedures
{
    public class FmsMovementSet
    {
        public FmsMovementSet()
        {
            Left = new FmsMovementData();
            Right = new FmsMovementData();
        }

        internal FmsMovementSet(FmsMovementData left, FmsMovementData right)
        {
            Left = left;
            Right = right;
        }

        public FmsMovementData Left { get; set; }
        public FmsMovementData Right { get; set; }

        public int Score => Left.Score < Right.Score
            ? Left.Score
            : Right.Score;

        public FmsMovementSet Build(FmsMovementData left, FmsMovementData right)
        {
            return new FmsMovementSet(left, right);
        }

        public override string ToString()
        {
            return $"{Left}\n{Right}";
        }
    }
}