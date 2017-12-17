using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekMDSuite.Procedures
{
    public class FunctionalMovementScreenBuilder
    {
        public FunctionalMovementScreen Build()
        {
            ValidatePreBuildState();
            return new FunctionalMovementScreen(_deepSquat, _hurdleStep, _inlineLunge, _shoulderMobility, _activeStraightLegRaise,
                _trunkStabilityPushup, _rotaryStability);
        }

        public FunctionalMovementScreenBuilder SetDeepSquat(int rawScore)
        {
            _deepSquat  = new FmsMovementData(FmsMovementPattern.DeepSquat, Laterality.Bilateral, rawScore, FmsClearanceTest.NotApplicable);
            return this;
        }

        public FunctionalMovementScreenBuilder SetHurdleStep(int leftScore, int rightScore)
        {
            _hurdleStep = new FmsMovementSet(
                new FmsMovementData(FmsMovementPattern.HurdleStep, Laterality.Left, leftScore, FmsClearanceTest.NotApplicable), 
                new FmsMovementData(FmsMovementPattern.HurdleStep, Laterality.Right, rightScore, FmsClearanceTest.NotApplicable)
                );
            return this;
        }

        public FunctionalMovementScreenBuilder SetInlineLunge(int leftScore, int rightScore)
        {
            _inlineLunge = new FmsMovementSet(
                new FmsMovementData(FmsMovementPattern.InlineLunge, Laterality.Left, leftScore, FmsClearanceTest.NotApplicable), 
                new FmsMovementData(FmsMovementPattern.InlineLunge, Laterality.Right, rightScore, FmsClearanceTest.NotApplicable)
            );
            return this;
        }

        public FunctionalMovementScreenBuilder SetShoulderMobility(int leftScore, FmsClearanceTest clearanceLeft, int rightScore, FmsClearanceTest clearanceRight)
        {
            _shoulderMobility = new FmsMovementSet(
                new FmsMovementData(FmsMovementPattern.ShoulderMobility, Laterality.Left, leftScore, clearanceLeft), 
                new FmsMovementData(FmsMovementPattern.ShoulderMobility, Laterality.Right, rightScore, clearanceRight)
            );
            return this;
        }

        public FunctionalMovementScreenBuilder SetActiveStraightLegRaise(int leftScore, int rightScore)
        {
            _activeStraightLegRaise = new FmsMovementSet(
                new FmsMovementData(FmsMovementPattern.ActiveStraightLegRaise, Laterality.Left, leftScore, FmsClearanceTest.NotApplicable), 
                new FmsMovementData(FmsMovementPattern.ActiveStraightLegRaise, Laterality.Right, rightScore, FmsClearanceTest.NotApplicable)
            );
            return this;
        }

        public FunctionalMovementScreenBuilder SetTrunkStabilityPuhsup(int rawScore, FmsClearanceTest clearanceTest)
        {
            _trunkStabilityPushup = new FmsMovementData(FmsMovementPattern.TrunkStability, Laterality.Bilateral, rawScore, clearanceTest);
            return this;
        }

        public FunctionalMovementScreenBuilder SetRotaryStability(int leftScore, FmsClearanceTest clearanceLeft, int rightScore, FmsClearanceTest clearanceRight)
        {
            _rotaryStability = new FmsMovementSet(
                new FmsMovementData(FmsMovementPattern.RotaryStability, Laterality.Left, leftScore, clearanceLeft), 
                new FmsMovementData(FmsMovementPattern.RotaryStability, Laterality.Right, rightScore, clearanceRight)
            );
            return this;
        }

        private FmsMovementData _deepSquat;
        private FmsMovementSet _hurdleStep;
        private FmsMovementSet _inlineLunge;
        private FmsMovementSet _shoulderMobility;
        private FmsMovementSet _activeStraightLegRaise;
        private FmsMovementData _trunkStabilityPushup;
        private FmsMovementSet _rotaryStability;

        private void ValidatePreBuildState()
        {
            var buildErrors = BuildErrorListForMissingFields();
            if (!string.IsNullOrEmpty(buildErrors))
                throw new MissingMethodException(nameof(FunctionalMovementScreenBuilder), BuildErrorListForMissingFields());
        }

        private string BuildErrorListForMissingFields()
        {
            var buildErrors = new List<string>();
            if (_deepSquat == null) buildErrors.Add(nameof(SetDeepSquat));
            if (_hurdleStep == null) buildErrors.Add(nameof(SetHurdleStep));
            if (_inlineLunge == null) buildErrors.Add(nameof(SetInlineLunge));
            if (_shoulderMobility == null) buildErrors.Add(nameof(SetShoulderMobility));
            if (_activeStraightLegRaise == null) buildErrors.Add(nameof(SetActiveStraightLegRaise));
            if (_trunkStabilityPushup == null) buildErrors.Add(nameof(SetTrunkStabilityPuhsup));
            if (_rotaryStability == null) buildErrors.Add(nameof(SetRotaryStability));
            
            return  buildErrors.Aggregate("", (current, error) => current + (error + " "));
        }
    }
}