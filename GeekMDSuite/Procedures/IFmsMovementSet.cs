namespace GeekMDSuite.Procedures
{
    public interface IFmsMovementSet
    {
        FmsMovementData Left { get; set; }
        FmsMovementData Right { get; set; }
        int Score { get; }
    }
}