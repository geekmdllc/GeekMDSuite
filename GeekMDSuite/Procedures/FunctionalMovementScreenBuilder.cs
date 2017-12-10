using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekMDSuite.Procedures
{
    public class FunctionalMovementScreenBuilder
    {
        public FunctionalMovementScreen Build()
        {
            ValidateFields();
            return new FunctionalMovementScreen(_deepSquat, _hurdleStep, _inlineLunge, _shoulderMobility, _activeStraightLegRaise,
                _trunkStabilityPushup, _rotaryStability);
        }

        public FunctionalMovementScreenBuilder SetDeepSquat(FmsMovement deepSquat)
        {
            _deepSquat = deepSquat;
            return this;
        }

        public FunctionalMovementScreenBuilder SetHurdleStep(FmsMovementSet hurdleStep)
        {
            _hurdleStep = hurdleStep;
            return this;
        }

        public FunctionalMovementScreenBuilder SetInlineLunge(FmsMovementSet inlineLunge)
        {
            _inlineLunge = inlineLunge;
            return this;
        }

        public FunctionalMovementScreenBuilder SetShoulderMobility(FmsMovementSet shoulderMobility)
        {
            _shoulderMobility = shoulderMobility;
            return this;
        }

        public FunctionalMovementScreenBuilder SetActiveStraightLegRaise(FmsMovementSet activeStraightLegRaise)
        {
            _activeStraightLegRaise = activeStraightLegRaise;
            return this;
        }

        public FunctionalMovementScreenBuilder SetTrunkStabilityPuhsup(FmsMovement trunkStabilityPushup)
        {
            _trunkStabilityPushup = trunkStabilityPushup;
            return this;
        }

        public FunctionalMovementScreenBuilder SetRotaryStability(FmsMovementSet rotaryStability)
        {
            _rotaryStability = rotaryStability;
            return this;
        }

        private FmsMovement _deepSquat;
        private FmsMovementSet _hurdleStep;
        private FmsMovementSet _inlineLunge;
        private FmsMovementSet _shoulderMobility;
        private FmsMovementSet _activeStraightLegRaise;
        private FmsMovement _trunkStabilityPushup;
        private FmsMovementSet _rotaryStability;

        private void ValidateFields()
        {
            var buildErrors = BuildErrorListForMissingFields();
            if (!string.IsNullOrEmpty(buildErrors))
                throw new MissingMethodException(nameof(FunctionalMovementScreenBuilder), BuildErrorListForMissingFields());
        }

        private string BuildErrorListForMissingFields()
        {
            var buildErrors = new List<string>();
            if (_deepSquat == null) buildErrors.Add("Deep Squat");
            if (_hurdleStep == null) buildErrors.Add("Hurdle Step");
            if (_inlineLunge == null) buildErrors.Add("Inline Lunge");
            if (_shoulderMobility == null) buildErrors.Add("Shoulder Mobility");
            if (_activeStraightLegRaise == null) buildErrors.Add("Active Straight Leg Raise");
            if (_trunkStabilityPushup == null) buildErrors.Add("Trunk Stability Pushup");
            if (_rotaryStability == null) buildErrors.Add("Rotary Stability");
            
            return  buildErrors.Aggregate("", (current, error) => current + (error + " "));
        }
    }
}