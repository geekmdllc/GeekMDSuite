using System;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Tools.MeasurementUnits;

namespace GeekMDSuite.Core.Models
{
    public class BodyCompositionBuilder : Builder<BodyCompositionBuilder, BodyComposition>
    {
        private double _heightInches;
        private double _hipsInches;
        private double _waistInches;
        private double _weightPounds;

        public override BodyComposition Build()
        {
            ValidatePreBuildState();
            return BodyComposition.Build(_heightInches, _waistInches, _hipsInches, _weightPounds);
        }

        public override BodyComposition BuildWithoutModelValidation()
        {
            return new BodyComposition
            {
                Height = Height.Build(_heightInches),
                Hips = Hips.Build(_hipsInches),
                Waist = Waist.Build(_waistInches),
                Weight = Weight.Build(_weightPounds)
            };
        }

        public BodyCompositionBuilder SetHeight(double inches)
        {
            _heightInches = inches;
            return this;
        }

        public BodyCompositionBuilder SetWaist(double inches)
        {
            _waistInches = inches;
            return this;
        }

        public BodyCompositionBuilder SetHips(double inches)
        {
            _hipsInches = inches;
            return this;
        }

        public BodyCompositionBuilder SetWeight(double pounds)
        {
            _weightPounds = pounds;
            return this;
        }

        private void ValidatePreBuildState()
        {
            var message = string.Empty;
            if (IsEffectivelyZero(_heightInches)) message += $"{nameof(SetHeight)} ";
            if (IsEffectivelyZero(_waistInches)) message += $"{nameof(SetWaist)} ";
            if (IsEffectivelyZero(_hipsInches)) message += $"{nameof(SetHips)} ";
            if (IsEffectivelyZero(_weightPounds)) message += $"{nameof(SetWeight)} ";

            if (!string.IsNullOrEmpty(message)) throw new MissingMethodException(message + " needs to be set.");
        }

        private static bool IsEffectivelyZero(double value)
        {
            return Math.Abs(value - default(double)) < 0.001;
        }
    }
}