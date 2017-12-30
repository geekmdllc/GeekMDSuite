using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekMDSuite.Procedures
{
    public class FunctionalMovementScreenBuilder : Builder<FunctionalMovementScreenBuilder, FunctionalMovementScreen>
    {
        public override FunctionalMovementScreen Build()
        {
            ValidatePreBuildState();
            return new FunctionalMovementScreen(_deepSquat, _hurdleStep, _inlineLunge, _shoulderMobility, _activeStraightLegRaise,
                _trunkStabilityPushup, _rotaryStability);
        }

        public FunctionalMovementScreenBuilder SetDeepSquat(int rawScore)
        {
            _deepSquat  = FmsMovementData.Build(FmsMovementPattern.DeepSquat, Laterality.Bilateral, rawScore, FmsClearanceTest.NotApplicable);
            return this;
        }

        public FunctionalMovementScreenBuilder SetHurdleStep(int leftScore, int rightScore)
        {
            _hurdleStep = new FmsMovementSet(
                FmsMovementData.Build(FmsMovementPattern.HurdleStep, Laterality.Left, leftScore, FmsClearanceTest.NotApplicable), 
                FmsMovementData.Build(FmsMovementPattern.HurdleStep, Laterality.Right, rightScore, FmsClearanceTest.NotApplicable)
                );
            return this;
        }

        public FunctionalMovementScreenBuilder SetInlineLunge(int leftScore, int rightScore)
        {
            _inlineLunge = new FmsMovementSet(
                FmsMovementData.Build(FmsMovementPattern.InlineLunge, Laterality.Left, leftScore, FmsClearanceTest.NotApplicable), 
                FmsMovementData.Build(FmsMovementPattern.InlineLunge, Laterality.Right, rightScore, FmsClearanceTest.NotApplicable)
            );
            return this;
        }

        public FunctionalMovementScreenBuilder SetShoulderMobility(int leftScore, bool leftPain, int rightScore, bool rightPain)
        {
            _shoulderMobility = new FmsMovementSet(
                FmsMovementData.Build(FmsMovementPattern.ShoulderMobility, Laterality.Left, leftScore, ParsePainResult(leftPain)), 
                FmsMovementData.Build(FmsMovementPattern.ShoulderMobility, Laterality.Right, rightScore, ParsePainResult(rightPain))
            );
            return this;
        }

        public FunctionalMovementScreenBuilder SetActiveStraightLegRaise(int leftScore, int rightScore)
        {
            _activeStraightLegRaise = new FmsMovementSet(
                FmsMovementData.Build(FmsMovementPattern.ActiveStraightLegRaise, Laterality.Left, leftScore, FmsClearanceTest.NotApplicable), 
                FmsMovementData.Build(FmsMovementPattern.ActiveStraightLegRaise, Laterality.Right, rightScore, FmsClearanceTest.NotApplicable)
            );
            return this;
        }

        public FunctionalMovementScreenBuilder SetTrunkStabilityPuhsup(int rawScore, bool pain)
        {
            _trunkStabilityPushup = FmsMovementData.Build(FmsMovementPattern.TrunkStability, Laterality.Bilateral, rawScore, ParsePainResult(pain));
            return this;
        }

        public FunctionalMovementScreenBuilder SetRotaryStability(int leftScore, int rightScore, bool pain)
        {
            _rotaryStability = new FmsMovementSet(
                FmsMovementData.Build(FmsMovementPattern.RotaryStability, Laterality.Left, leftScore, ParsePainResult(pain)), 
                FmsMovementData.Build(FmsMovementPattern.RotaryStability, Laterality.Right, rightScore, ParsePainResult(pain))
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
        
        private static FmsClearanceTest ParsePainResult(bool leftPain) 
            => leftPain ? FmsClearanceTest.Positive : FmsClearanceTest.Negative;

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