using System;
using GeekMDSuite.Core.Tools.MeasurementUnits;

namespace GeekMDSuite.Core
{
    public class BodyCompositionExpandedBuilder : Builder<BodyCompositionExpandedBuilder,BodyCompositionExpanded>
    {
        public override BodyCompositionExpanded Build()
        {
            ValidatePreBuildState();
            return BodyCompositionExpanded.Build(
                BodyComposition.Build(_heightInches, _waistInches, _hipsInches, _weightPounds), 
                _visceralFatCm2, _percentBodyFat);
        }

        public override BodyCompositionExpanded BuildWithoutModelValidation()
        {
            return new BodyCompositionExpanded()
            {
                Height = Height.Build(_heightInches),
                Waist = Waist.Build(_waistInches),
                Hips = Hips.Build(_hipsInches),
                Weight = Weight.Build(_weightPounds),
                VisceralFat = _visceralFatCm2,
                PercentBodyFat = _percentBodyFat
            };
        }

        public BodyCompositionExpandedBuilder SetHeight(double inches)
        {
            _heightInches = inches;
            return this;
        }

        public BodyCompositionExpandedBuilder SetWaist(double inches)
        {
            _waistInches = inches;
            return this;
        }
        
        public BodyCompositionExpandedBuilder SetHips(double inches)
        {
            _hipsInches = inches;
            return this;
        }
        
        public BodyCompositionExpandedBuilder SetWeight(double pounds)
        {
            _weightPounds = pounds;
            return this;
        }
        
        public BodyCompositionExpandedBuilder SetVisceralFat(double centimetersSquared)
        {
            _visceralFatCm2 = centimetersSquared;
            return this;
        }
        
        public BodyCompositionExpandedBuilder SetBodyFatPercentage(double percentage)
        {
            _percentBodyFat = percentage;
            return this;
        }
            
        private double _heightInches;
        private double _waistInches;
        private double _hipsInches;
        private double _weightPounds;
        private double _visceralFatCm2;
        private double _percentBodyFat;
        
        private void ValidatePreBuildState()
        {
            var message = string.Empty;
            if (IsEffectivelyZero(_heightInches)) message += $"{nameof(SetHeight)} ";
            if (IsEffectivelyZero(_waistInches)) message += $"{nameof(SetWaist)} ";
            if (IsEffectivelyZero(_hipsInches)) message += $"{nameof(SetHips)} ";
            if (IsEffectivelyZero(_weightPounds)) message += $"{nameof(SetWeight)} ";
            if (IsEffectivelyZero(_visceralFatCm2)) message += $"{nameof(SetVisceralFat)} ";
            if (IsEffectivelyZero(_percentBodyFat)) message += $"{nameof(SetBodyFatPercentage)} ";
            
            if (!string.IsNullOrEmpty(message)) throw new MissingMethodException(message + " needs to be set.");
        }

        private static bool IsEffectivelyZero(double value) => Math.Abs(value - default(double)) < 0.001;
    }
}