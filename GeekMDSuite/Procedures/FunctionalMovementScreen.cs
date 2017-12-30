namespace GeekMDSuite.Procedures
{
    public class FunctionalMovementScreen : IFunctionalMovementScreen
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

        public FmsMovementData DeepSquat { get; set; } 

        public FmsMovementSet HurdleStep { get; set; }

        public FmsMovementSet InlineLunge { get; set; }

        public FmsMovementSet ShoulderMobility { get; set; }

        public FmsMovementSet ActiveStraightLegRaise { get; set; }

        public FmsMovementData TrunkStabilityPushup { get; set; } 

        public FmsMovementSet RotaryStability { get; set; }

        public override string ToString() => 
            $"{DeepSquat}\n{HurdleStep}\n{InlineLunge}\n{ShoulderMobility}\n{ActiveStraightLegRaise}\n{TrunkStabilityPushup}\n{RotaryStability}";

        public FunctionalMovementScreen()
        {
            
        }
    }
}