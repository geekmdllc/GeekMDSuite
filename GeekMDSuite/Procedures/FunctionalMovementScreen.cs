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

        public FmsMovement DeepSquat { get;  } // => (value.Data.MovementPattern == FmsMovementPattern.DeepSquat ? value : null);

        public FmsMovementSet HurdleStep { get; }// => (IsExpectedMovementPattern(value, FmsMovementPattern.HurdleStep) ? value : null);

        public FmsMovementSet InlineLunge { get; }// => (IsExpectedMovementPattern(value, FmsMovementPattern.InlineLunge) ? value : null);

        public FmsMovementSet ShoulderMobility { get; }// => (IsExpectedMovementPattern(value, FmsMovementPattern.ShoulderMobility) ? value : null);

        public FmsMovementSet ActiveStraightLegRaise { get; }// => (IsExpectedMovementPattern(value, FmsMovementPattern.ActiveStraightLegRaise) ? value : null);

        public FmsMovement TrunkStabilityPushup { get; } // => (value.Data.MovementPattern == FmsMovementPattern.TrunkStability ? value : null);

        public FmsMovementSet RotaryStability { get; } // => IsExpectedMovementPattern(value, FmsMovementPattern.RotaryStability) ? value : null);

        private bool IsExpectedMovementPattern(FmsMovementSet movementSet, FmsMovementPattern expectedMovementPattern)
        {
            return (movementSet.DataLeft.MovementPattern == expectedMovementPattern &&
                    movementSet.DataRight.MovementPattern == expectedMovementPattern ? true : false);
        }
    }
}