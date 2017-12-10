namespace GeekMDSuite.Procedures
{
    public class FunctionalMovementScreen
    {
        internal FunctionalMovementScreen(
            FmsMovement deepSquat, 
            FmsMovementSet hurdleStep, 
            FmsMovementSet inlineLunge, 
            FmsMovementSet shoulderMobility, 
            FmsMovementSet activeStraightLegRaise, 
            FmsMovement trunkStabilityPushup, 
            FmsMovementSet rotaryStability)
        {
            DeepSquat = deepSquat;
            HurdleStep = hurdleStep;
            InlineLunge = inlineLunge;
            ShoulderMobility = shoulderMobility;
            ActiveStraightLegRaise = activeStraightLegRaise;
            TrunkStabilityPushup = trunkStabilityPushup;
            RotaryStability = rotaryStability;
        }

        public FmsMovement DeepSquat { get;  } 

        public FmsMovementSet HurdleStep { get; }

        public FmsMovementSet InlineLunge { get; }

        public FmsMovementSet ShoulderMobility { get; }

        public FmsMovementSet ActiveStraightLegRaise { get; }

        public FmsMovement TrunkStabilityPushup { get; } 

        public FmsMovementSet RotaryStability { get; } 
    }
}