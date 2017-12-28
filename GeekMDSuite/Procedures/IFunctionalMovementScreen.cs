namespace GeekMDSuite.Procedures
{
    public interface IFunctionalMovementScreen
    {
        FmsMovementData DeepSquat { get; }
        FmsMovementSet HurdleStep { get; }
        FmsMovementSet InlineLunge { get; }
        FmsMovementSet ShoulderMobility { get; }
        FmsMovementSet ActiveStraightLegRaise { get; }
        FmsMovementData TrunkStabilityPushup { get; }
        FmsMovementSet RotaryStability { get; }
    }
}