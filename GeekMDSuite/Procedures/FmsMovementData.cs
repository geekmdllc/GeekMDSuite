using System;

namespace GeekMDSuite.Procedures
{
    public class FmsMovementData
    {
        internal FmsMovementData(
            FmsMovementPattern movementPattern, 
            Laterality laterality, 
            int rawScore, 
            FmsClearanceTest clearance)
        {
            MovementPattern = movementPattern;
            RawScore = ValidateAndSetRawScore(rawScore);
            Clearance = MovementHasClearanceTest ? clearance : FmsClearanceTest.NotApplicable;
            Laterality = MovementHasUnilateralLaterality ? laterality : Laterality.Bilateral;
        }

        public FmsMovementPattern MovementPattern { get; }
        public Laterality Laterality { get; }
        private int RawScore { get; }
        public int Score => Clearance == FmsClearanceTest.Positive ? 0 : RawScore;
        public FmsClearanceTest Clearance { get; }

        private static int ValidateAndSetRawScore(int rawScore) => rawScore >= 0 && rawScore <= 3 
            ? rawScore : throw new ArgumentOutOfRangeException("rawScore", "Must be between 0 and 3.");

        private bool MovementHasUnilateralLaterality => !(MovementPattern == FmsMovementPattern.DeepSquat ||
                                               MovementPattern == FmsMovementPattern.TrunkStability);

        private bool MovementHasClearanceTest => MovementPattern == FmsMovementPattern.ShoulderMobility ||
                                                 MovementPattern == FmsMovementPattern.TrunkStability ||
                                                 MovementPattern == FmsMovementPattern.RotaryStability;
    }
}