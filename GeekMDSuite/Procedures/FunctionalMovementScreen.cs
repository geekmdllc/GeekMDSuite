namespace GeekMDSuite.Procedures
{
    public class FunctionalMovementScreen
    {
        internal FunctionalMovementScreen(
            FmsMovementData deepSquat, 
            FmsMovementSet hurdleStep, 
            FmsMovementSet inlineLunge, 
            FmsMovementSet shoulderMobility, 
            FmsMovementSet activeStraightLegRaise, 
            FmsMovementData trunkStabilityPushup, 
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

        public FmsMovementData DeepSquat { get;  } 

        public FmsMovementSet HurdleStep { get; }

        public FmsMovementSet InlineLunge { get; }

        public FmsMovementSet ShoulderMobility { get; }

        public FmsMovementSet ActiveStraightLegRaise { get; }

        public FmsMovementData TrunkStabilityPushup { get; } 

        public FmsMovementSet RotaryStability { get; }

        public override string ToString() => 
            $"{DeepSquat}\n{HurdleStep}\n{InlineLunge}\n{ShoulderMobility}\n{ActiveStraightLegRaise}\n{TrunkStabilityPushup}\n{RotaryStability}";
    }
}