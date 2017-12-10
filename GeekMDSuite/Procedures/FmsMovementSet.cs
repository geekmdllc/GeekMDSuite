namespace GeekMDSuite.Procedures
{
    public class FmsMovementSet
    {
        internal FmsMovementSet(FmsMovementData dataLeft, FmsMovementData dataRight)
        {
            DataLeft = dataLeft;
            DataRight = dataRight;
        }

        public FmsMovementData DataLeft { get; }
        public FmsMovementData DataRight { get; }
    }
}