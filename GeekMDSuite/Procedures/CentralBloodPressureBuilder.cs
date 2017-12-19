using System;

namespace GeekMDSuite.Procedures
{
    public class CentralBloodPressureBuilder : IBuilder<CentralBloodPressure>
    {
        public CentralBloodPressure Build()
        {
            ValidatePreBuildState();
            return CentralBloodPressure.Build(_systolicPressure, _pulsePressure, _augmentedPressure, _augmentedIndex, _referenceAge, _pulseWaveVelocity);
        }

        public CentralBloodPressureBuilder SetCentralSystolicPressure(double pressure)
        {
            _systolicPressure = pressure;
            return this;
        }

        public CentralBloodPressureBuilder SetPulsePressure(double pressure)
        {
            _pulsePressure = pressure;
            return this;
        }

        public CentralBloodPressureBuilder SetAugmentedPressure(double pressure)
        {
            _augmentedPressure = pressure;
            return this;
        }

        public CentralBloodPressureBuilder SetAugmentedIndex(double indexPercent)
        {
            _augmentedIndex = indexPercent;
            return this;
        }

        public CentralBloodPressureBuilder SetReferenceAge(double years)
        {
            _referenceAge = years;
            return this;
        }

        public CentralBloodPressureBuilder SetPulseWaveVelocity(double velocity)
        {
            _pulseWaveVelocity = velocity;
            return this;
        }
        
        private double _systolicPressure = double.MinValue;
        private double _pulsePressure = double.MinValue;
        private double _augmentedPressure = double.MinValue;
        private double _augmentedIndex = double.MinValue;
        private double _referenceAge = double.MinValue;
        private double _pulseWaveVelocity = double.MinValue;
        
        private void ValidatePreBuildState()
        {
            var message = string.Empty;
            if (IsEffectivelyZero(_systolicPressure)) message += $"{nameof(SetCentralSystolicPressure)} ";
            if (IsEffectivelyZero(_pulsePressure)) message += $"{nameof(SetPulsePressure)} ";
            if (IsEffectivelyZero(_augmentedPressure)) message += $"{nameof(SetAugmentedPressure)} ";
            if (IsEffectivelyZero(_augmentedIndex)) message += $"{nameof(SetAugmentedIndex)} ";
            if (IsEffectivelyZero(_referenceAge)) message += $"{nameof(SetReferenceAge)} ";
            if (IsEffectivelyZero(_pulseWaveVelocity)) message += $"{nameof(SetPulseWaveVelocity)} ";
            
            if (!string.IsNullOrEmpty(message)) throw new MissingMethodException(message + "need to be set");
        }

        private static bool IsEffectivelyZero(double value)
        {
            return Math.Abs(value - double.MinValue) < 0.001;
        }

    }
}