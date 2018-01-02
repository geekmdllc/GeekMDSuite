namespace GeekMDSuite.Core.Procedures
{
    public interface IFmsMovementData
    {
        FmsMovementPattern MovementPattern { get; set; }
        Laterality Laterality { get; set; }
        int Score { get; }
        FmsClearanceTest Clearance { get; set; }
    }
}