using System;
using System.ComponentModel;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class FunctionalMovementScreenInterpretation : IInterpretable<FunctionalMovementScreenClassification>
    {
        public InterpretationText Interpretation => throw new NotImplementedException();
        public FunctionalMovementScreenClassification Classification => Classify();


        public FunctionalMovementScreenInterpretation(FunctionalMovementScreen fms)
        {
            _fms = fms;
        }

        private readonly FunctionalMovementScreen _fms;
        
        private FunctionalMovementScreenClassification Classify()
        {
            return new FunctionalMovementScreenClassification(
                ClassifyMovement(_fms.DeepSquat),
                ClassifyMovement(_fms.HurdleStep),
                ClassifyMovement(_fms.ShoulderMobility),
                ClassifyMovement(_fms.InlineLunge),
                ClassifyMovement(_fms.ActiveStraightLegRaise),
                ClassifyMovement(_fms.TrunkStabilityPushup),
                ClassifyMovement(_fms.RotaryStability)
            );
        }

        private static FmsMovementClassification ClassifyMovement(FmsMovementSet movementSet)
        {
            return new FmsMovementClassification(
                MovementSetClassification.CalculateFlag(movementSet),
                MovementSetClassification.RecommendedAction(movementSet)
            );
        }
        
        private static FmsMovementClassification ClassifyMovement(FmsMovementData movementSet)
        {
            return new FmsMovementClassification(
                MovementClassification.CalculateFlag(movementSet),
                MovementClassification.RecommendedAction(movementSet)
            );
        }

        private static class MovementClassification
        {
            public static FmsScoreFlag CalculateFlag(FmsMovementData movement)
            {
                var score = movement.ComponentScore;
                
                if (score == 0)
                    return FmsScoreFlag.L0R0;
                if (score == 1)
                    return FmsScoreFlag.L1R1;
                if (score == 2)
                    return FmsScoreFlag.L2R2;
                if (score == 3)
                    return FmsScoreFlag.L3R3;
                throw new ArgumentOutOfRangeException(nameof(score));
            }

            public static FmsRecommendedAction RecommendedAction(FmsMovementData movement)
            {
                var flag = CalculateFlag(movement);
                
                if (flag == FmsScoreFlag.L0R0)
                    return FmsRecommendedAction.MedicalAttention;
                if (flag == FmsScoreFlag.L1R1)
                    return FmsRecommendedAction.Restricted;
                if (flag == FmsScoreFlag.L2R2 || flag == FmsScoreFlag.L3R3)
                    return FmsRecommendedAction.Unrestricted;
                throw new InvalidEnumArgumentException(nameof(flag));
            }
        }

        private static class MovementSetClassification
        {
            public static FmsScoreFlag CalculateFlag(FmsMovementSet set)
            {
                var left = set.DataLeft;
                var right = set.DataRight;
                
                switch(left.ComponentScore) {
                    default:
                        switch(right.ComponentScore) {
                            default:
                                return FmsScoreFlag.L0R0;
                            case 1:
                                return FmsScoreFlag.L0R1;
                            case 2:
                                return FmsScoreFlag.L0R2;
                            case 3:
                                return FmsScoreFlag.L0R3;
                        }
                    case 1:
                        switch(right.ComponentScore) {
                            default:
                                return FmsScoreFlag.L1R0;
                            case 1:
                                return FmsScoreFlag.L1R1;
                            case 2:
                                return FmsScoreFlag.L1R2;
                            case 3:
                                return FmsScoreFlag.L1R3;
                        }
                    case 2:
                        switch(right.ComponentScore) {
                            default:
                                return FmsScoreFlag.L2R0;
                            case 1:
                                return FmsScoreFlag.L2R1;
                            case 2:
                                return FmsScoreFlag.L2R2;
                            case 3:
                                return FmsScoreFlag.L2R3;
                        }
                    case 3:
                        switch(right.ComponentScore) {
                            default:
                                return FmsScoreFlag.L3R0;
                            case 1:
                                return FmsScoreFlag.L3R1;
                            case 2:
                                return FmsScoreFlag.L3R2;
                            case 3:
                                return FmsScoreFlag.L3R3;
                    }
            }
        }
        // Recommended actions to take include laterality. The 
        // calculated score only contributes to the total score
        // and if the total score is below a threshold a flag is 
        // thrown. But, assymetry also has importance.
        public static FmsRecommendedAction RecommendedAction(FmsMovementSet fmsMovementSet)
        {
            var flag = CalculateFlag(fmsMovementSet);
            switch (flag) {
                // Zero scores anywhere require medical attention
                case FmsScoreFlag.L0R0:
                case FmsScoreFlag.L0R1:
                case FmsScoreFlag.L0R2:
                case FmsScoreFlag.L0R3:
                case FmsScoreFlag.L1R0:
                case FmsScoreFlag.L2R0:
                case FmsScoreFlag.L3R0:
                    return FmsRecommendedAction.MedicalAttention;
                // 1s or assymetry require caution (restricted)
                case FmsScoreFlag.L1R1:
                case FmsScoreFlag.L1R2:
                case FmsScoreFlag.L1R3:
                case FmsScoreFlag.L2R1:
                case FmsScoreFlag.L2R3:
                case FmsScoreFlag.L3R1:
                case FmsScoreFlag.L3R2:
                    return FmsRecommendedAction.Restricted;
                // Symmetric 2's and 3's do not require significant supervision.
                case FmsScoreFlag.L2R2:
                case FmsScoreFlag.L3R3:
                    return FmsRecommendedAction.Unrestricted;
                default:
                    throw new InvalidEnumArgumentException(nameof(flag));
                
            }
        }
        }
    }
    
    
}