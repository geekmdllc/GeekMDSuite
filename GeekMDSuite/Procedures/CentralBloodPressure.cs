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

        public double SystolicPressure { get; set; }
        public double PulsePressure { get; set; }
        public double AugmentedPressure { get; set; }
        public double AugmentedIndex { get; set; }
        public double ReferenceAge { get; set; }
        public double PulseWaveVelocity { get; set; }

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

        protected internal CentralBloodPressure()
        {
            
        }
    }
}