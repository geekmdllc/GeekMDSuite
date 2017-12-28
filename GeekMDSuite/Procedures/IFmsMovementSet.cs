namespace GeekMDSuite.Procedures
{
    public interface IFmsMovementSet
    {
        FmsMovementData Left { get; }
        FmsMovementData Right { get; }
        int Score { get; }
    }
}