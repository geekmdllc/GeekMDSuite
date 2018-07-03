using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class FunctionalMovementScreenEntity : FunctionalMovementScreen, IMapProperties<FunctionalMovementScreen>,
        IVisitData
    {
        public FunctionalMovementScreenEntity()
        {
            ActiveStraightLegRaise = new FmsMovementSet();
            DeepSquat = new FmsMovementData();
            HurdleStep = new FmsMovementSet();
            InlineLunge = new FmsMovementSet();
            RotaryStability = new FmsMovementSet();
            ShoulderMobility = new FmsMovementSet();
            TrunkStabilityPushup = new FmsMovementData();
            VisitGuid = Guid.Empty;
        }

        public FunctionalMovementScreenEntity(FunctionalMovementScreen functionalMovementScreen) : this()
        {
            MapValues(functionalMovementScreen);
        }

        public void MapValues(FunctionalMovementScreen subject)
        {
            MapTrunkStability(subject);
            MapDeepSquat(subject);
            MapActiveStraightLegRaise(subject);
            MapHurdleStep(subject);
            MapInlineLunge(subject);
            MapRotaryStability(subject);
            MapShoulderMobility(subject);
        }

        public int Id { get; set; }
        public Guid VisitGuid { get; set; }

        private void MapShoulderMobility(FunctionalMovementScreen subject)
        {
            ShoulderMobility.Left.Clearance = subject.ShoulderMobility.Left.Clearance;
            ShoulderMobility.Left.Laterality = subject.ShoulderMobility.Left.Laterality;
            ShoulderMobility.Left.MovementPattern = subject.ShoulderMobility.Left.MovementPattern;
            ShoulderMobility.Left.RawScore = subject.ShoulderMobility.Left.RawScore;
            ShoulderMobility.Right.Clearance = subject.ShoulderMobility.Right.Clearance;
            ShoulderMobility.Right.Laterality = subject.ShoulderMobility.Right.Laterality;
            ShoulderMobility.Right.MovementPattern = subject.ShoulderMobility.Right.MovementPattern;
            ShoulderMobility.Right.RawScore = subject.ShoulderMobility.Right.RawScore;
        }

        private void MapRotaryStability(FunctionalMovementScreen subject)
        {
            RotaryStability.Left.Clearance = subject.RotaryStability.Left.Clearance;
            RotaryStability.Left.Laterality = subject.RotaryStability.Left.Laterality;
            RotaryStability.Left.MovementPattern = subject.RotaryStability.Left.MovementPattern;
            RotaryStability.Left.RawScore = subject.RotaryStability.Left.RawScore;
            RotaryStability.Right.Clearance = subject.RotaryStability.Right.Clearance;
            RotaryStability.Right.Laterality = subject.RotaryStability.Right.Laterality;
            RotaryStability.Right.MovementPattern = subject.RotaryStability.Right.MovementPattern;
            RotaryStability.Right.RawScore = subject.RotaryStability.Right.RawScore;
        }

        private void MapInlineLunge(FunctionalMovementScreen subject)
        {
            InlineLunge.Left.Clearance = subject.InlineLunge.Left.Clearance;
            InlineLunge.Left.Laterality = subject.InlineLunge.Left.Laterality;
            InlineLunge.Left.MovementPattern = subject.InlineLunge.Left.MovementPattern;
            InlineLunge.Left.RawScore = subject.InlineLunge.Left.RawScore;
            InlineLunge.Right.Clearance = subject.InlineLunge.Right.Clearance;
            InlineLunge.Right.Laterality = subject.InlineLunge.Right.Laterality;
            InlineLunge.Right.MovementPattern = subject.InlineLunge.Right.MovementPattern;
            InlineLunge.Right.RawScore = subject.InlineLunge.Right.RawScore;
        }

        private void MapHurdleStep(FunctionalMovementScreen subject)
        {
            HurdleStep.Left.Clearance = subject.HurdleStep.Left.Clearance;
            HurdleStep.Left.Laterality = subject.HurdleStep.Left.Laterality;
            HurdleStep.Left.MovementPattern = subject.HurdleStep.Left.MovementPattern;
            HurdleStep.Left.RawScore = subject.HurdleStep.Left.RawScore;
            HurdleStep.Right.Clearance = subject.HurdleStep.Right.Clearance;
            HurdleStep.Right.Laterality = subject.HurdleStep.Right.Laterality;
            HurdleStep.Right.MovementPattern = subject.HurdleStep.Right.MovementPattern;
            HurdleStep.Right.RawScore = subject.HurdleStep.Right.RawScore;
        }

        private void MapActiveStraightLegRaise(FunctionalMovementScreen subject)
        {
            ActiveStraightLegRaise.Left.Clearance = subject.ActiveStraightLegRaise.Left.Clearance;
            ActiveStraightLegRaise.Left.Laterality = subject.ActiveStraightLegRaise.Left.Laterality;
            ActiveStraightLegRaise.Left.MovementPattern = subject.ActiveStraightLegRaise.Left.MovementPattern;
            ActiveStraightLegRaise.Left.RawScore = subject.ActiveStraightLegRaise.Left.RawScore;
            ActiveStraightLegRaise.Right.Clearance = subject.ActiveStraightLegRaise.Right.Clearance;
            ActiveStraightLegRaise.Right.Laterality = subject.ActiveStraightLegRaise.Right.Laterality;
            ActiveStraightLegRaise.Right.MovementPattern = subject.ActiveStraightLegRaise.Right.MovementPattern;
            ActiveStraightLegRaise.Right.RawScore = subject.ActiveStraightLegRaise.Right.RawScore;
        }

        private void MapDeepSquat(FunctionalMovementScreen subject)
        {
            DeepSquat.Clearance = subject.DeepSquat.Clearance;
            DeepSquat.Laterality = subject.DeepSquat.Laterality;
            DeepSquat.MovementPattern = subject.DeepSquat.MovementPattern;
            DeepSquat.RawScore = subject.DeepSquat.RawScore;
        }

        private void MapTrunkStability(FunctionalMovementScreen subject)
        {
            TrunkStabilityPushup.Clearance = subject.TrunkStabilityPushup.Clearance;
            TrunkStabilityPushup.Laterality = subject.TrunkStabilityPushup.Laterality;
            TrunkStabilityPushup.MovementPattern = subject.TrunkStabilityPushup.MovementPattern;
            TrunkStabilityPushup.RawScore = subject.TrunkStabilityPushup.RawScore;
        }
    }
}