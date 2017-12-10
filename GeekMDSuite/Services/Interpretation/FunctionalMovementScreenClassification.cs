namespace GeekMDSuite.Services.Interpretation
{
    public class FunctionalMovementScreenClassification
    {
        internal FunctionalMovementScreenClassification(
            FmsMovementClassification deepSquat,
            FmsMovementClassification hurdleStep,
            FmsMovementClassification shoulderMobility,
            FmsMovementClassification inlineLunge,
            FmsMovementClassification activeStraightLegRaise,
            FmsMovementClassification trunkStabilityPushup,
            FmsMovementClassification rotaryStability)
        {
            DeepSquat = deepSquat;
            HurdleStep = hurdleStep;
            ShoulderMobility = shoulderMobility;
            InlineLunge = inlineLunge;
            ActiveStraightLegRaise = activeStraightLegRaise;
            TrunkStabilityPushup = trunkStabilityPushup;
            RotaryStability = rotaryStability;
        }

        public FmsMovementClassification DeepSquat { get; }
        public FmsMovementClassification HurdleStep { get; }
        public FmsMovementClassification ShoulderMobility { get; }
        public FmsMovementClassification InlineLunge { get; }
        public FmsMovementClassification ActiveStraightLegRaise { get; }
        public FmsMovementClassification TrunkStabilityPushup { get; }
        public FmsMovementClassification RotaryStability { get; }

        //TODO: Refactor so that this can be scored; likely need to move methods from Interpretation section
//        public int Score()
//        {
//            return DeepSquat.Score + HurdleStep.Score + ShoulderMobility.Score +
//                   InlineLunge.Score + InlineLunge.Score + ActiveStraightLegRaise.Score +
//                   TrunkStabilityPushup.Score + RotaryStability.Score;
//        }
}
}