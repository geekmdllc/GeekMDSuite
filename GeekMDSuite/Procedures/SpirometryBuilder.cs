using System;

namespace GeekMDSuite.Procedures
{
    public class SpirometryBuilder : IBuilder<Spirometry>
    {
        public Spirometry Build()
        {
            ValidatePreBuildState();
            return new Spirometry(_forcedExpiratoryVolume1Second, 
                _forcedVitalCapacity, 
                _peakExpiratoryFlow, 
                _forcedExpiratoryFlow25To75, 
                _forcedExpiratoryTime);
        }
        
        public SpirometryBuilder SetForcedExpiratoryVolume1Second(double liters)
        {
            _forcedExpiratoryVolume1Second = liters;
            return this;
        }

        public SpirometryBuilder SetForcedVitalCapacity(double liters)
        {
            _forcedVitalCapacity = liters;
            return this;
        }

        public SpirometryBuilder SetPeakExpiratoryFlow(double litersPerSecond)
        {
            _peakExpiratoryFlow = litersPerSecond;
            return this;
        }

        public SpirometryBuilder SetForcedExpiratoryFlow25To75(double litersPerSecond)
        {
            _forcedExpiratoryFlow25To75 = litersPerSecond;
            return this;
        }

        public SpirometryBuilder SetForcedExpiratoryTime(double seconds)
        {
            _forcedExpiratoryTime = seconds;
            return this;
        }
        
        private double _forcedExpiratoryVolume1Second;
        private double _forcedVitalCapacity;
        private double _peakExpiratoryFlow;
        private double _forcedExpiratoryFlow25To75;
        private double _forcedExpiratoryTime;
        private void ValidatePreBuildState()
        
        {
            var message = string.Empty;
            if (IsEffectivelyZero(_forcedExpiratoryVolume1Second)) message += $"{nameof(SetForcedExpiratoryVolume1Second)} ";
            if (IsEffectivelyZero(_forcedVitalCapacity)) message += $"{nameof(SetForcedVitalCapacity)} ";
            if (IsEffectivelyZero(_peakExpiratoryFlow)) message += $"{nameof(SetPeakExpiratoryFlow)} ";
            if (IsEffectivelyZero(_forcedExpiratoryFlow25To75)) message += $"{nameof(SetForcedExpiratoryFlow25To75)} ";
            if (IsEffectivelyZero(_forcedExpiratoryTime)) message += $"{nameof(_forcedExpiratoryTime)} ";

            if (!string.IsNullOrEmpty(message)) throw new MissingMethodException($"{message} should be set");
        }

        private static bool IsEffectivelyZero(double value) => Math.Abs(value - default(double)) < 0.001;
    }
}