using System;

namespace GeekMDSuite.Core.Models.Procedures
{
    public class FmsMovementData
    {
        public FmsMovementData()
        {
        }

        private FmsMovementData(
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

        public FmsMovementPattern MovementPattern { get; set; }
        public Laterality Laterality { get; set; }
        public int Score => Clearance == FmsClearanceTest.Positive ? 0 : RawScore;
        public FmsClearanceTest Clearance { get; set; }

        public int RawScore { get; set; }

        private bool MovementHasUnilateralLaterality => !(MovementPattern == FmsMovementPattern.DeepSquat ||
                                                          MovementPattern == FmsMovementPattern.TrunkStability);

        private bool MovementHasClearanceTest => MovementPattern == FmsMovementPattern.ShoulderMobility ||
                                                 MovementPattern == FmsMovementPattern.TrunkStability ||
                                                 MovementPattern == FmsMovementPattern.RotaryStability;

        public static FmsMovementData Build(
            FmsMovementPattern movementPattern,
            Laterality laterality,
            int rawScore,
            FmsClearanceTest clearance)
        {
            return new FmsMovementData(movementPattern, laterality, rawScore, clearance);
        }

        private static int ValidateAndSetRawScore(int rawScore)
        {
            return rawScore >= 0 && rawScore <= 3
                ? rawScore
                : throw new ArgumentOutOfRangeException("rawScore", "Must be between 0 and 3.");
        }

        public override string ToString()
        {
            return $"{MovementPattern} " +
                   (Laterality == Laterality.Bilateral ? "" : $"({Laterality}) ") +
                   $"Score: {Score}" +
                   (Clearance == FmsClearanceTest.NotApplicable ? "" : $" Pain: {Clearance}");
        }
    }
}