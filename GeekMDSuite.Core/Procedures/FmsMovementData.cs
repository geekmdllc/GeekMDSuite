using System;

namespace GeekMDSuite.Core.Procedures
{
    public class FmsMovementData : IFmsMovementData
    {
        public static FmsMovementData Build (
            FmsMovementPattern movementPattern, 
            Laterality laterality, 
            int rawScore, 
            FmsClearanceTest clearance)
        {
            return new FmsMovementData(movementPattern, laterality, rawScore, clearance);
        }

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

        private static int ValidateAndSetRawScore(int rawScore) => rawScore >= 0 && rawScore <= 3 
            ? rawScore : throw new ArgumentOutOfRangeException("rawScore", "Must be between 0 and 3.");

        private bool MovementHasUnilateralLaterality => !(MovementPattern == FmsMovementPattern.DeepSquat ||
                                               MovementPattern == FmsMovementPattern.TrunkStability);

        private bool MovementHasClearanceTest => MovementPattern == FmsMovementPattern.ShoulderMobility ||
                                                 MovementPattern == FmsMovementPattern.TrunkStability ||
                                                 MovementPattern == FmsMovementPattern.RotaryStability;

        public override string ToString() => $"{MovementPattern} " +
                                             (Laterality == Laterality.Bilateral ? "" : $"({Laterality}) ") +
                                             $"Score: {Score}" + 
                                             (Clearance == FmsClearanceTest.NotApplicable ? "" : $" Pain: {Clearance}");
    }
}