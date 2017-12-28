namespace GeekMDSuite.Procedures
{
    public interface IFmsMovementData
    {
        FmsMovementPattern MovementPattern { get; }
        Laterality Laterality { get; }
        int Score { get; }
        FmsClearanceTest Clearance { get; }
    }
}