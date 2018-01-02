namespace GeekMDSuite.Core.Procedures
{
    public interface IFunctionalMovementScreen
    {
        FmsMovementData DeepSquat { get; set; }
        FmsMovementSet HurdleStep { get; set; }
        FmsMovementSet InlineLunge { get; set; }
        FmsMovementSet ShoulderMobility { get; set; }
        FmsMovementSet ActiveStraightLegRaise { get; set; }
        FmsMovementData TrunkStabilityPushup { get; set; }
        FmsMovementSet RotaryStability { get; set; }
    }
}