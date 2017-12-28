namespace GeekMDSuite.Procedures
{
    public class CentralBloodPressure : ICentralBloodPressure
    {
        
        public static CentralBloodPressure Build(
            double systolicPressure,
            double pulsePressure,
            double augmentedPressure,
            double augmentedIndex,
            double referenceAge,
            double pulseWaveVelocity) => 
            new CentralBloodPressure(systolicPressure, pulsePressure, augmentedPressure, augmentedIndex, referenceAge, pulseWaveVelocity);

        public double SystolicPressure { get; }
        public double PulsePressure { get; }
        public double AugmentedPressure { get; }
        public double AugmentedIndex { get; }
        public double ReferenceAge { get;  }
        public double PulseWaveVelocity { get;  }

        public override string ToString() => 
            $"CSP {SystolicPressure} mmHg PP {PulsePressure} mmHg AP {PulsePressure} mmHg AIx {AugmentedIndex}% Ref Age {ReferenceAge} yrs PWV {PulseWaveVelocity} m/s";
        
                
        private CentralBloodPressure(
            double systolicPressure, 
            double pulsePressure, 
            double augmentedPressure, 
            double augmentedIndex, 
            double referenceAge, 
            double pulseWaveVelocity)
        {
            SystolicPressure = systolicPressure;
            PulsePressure = pulsePressure;
            AugmentedPressure = augmentedPressure;
            AugmentedIndex = augmentedIndex;
            ReferenceAge = referenceAge;
            PulseWaveVelocity = pulseWaveVelocity;
        }
    }
}