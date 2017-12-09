namespace GeekMDSuite.Procedures
{
    public class CentralBloodPressure
    {
        public CentralBloodPressure(
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

        public double SystolicPressure { get; }
        public double PulsePressure { get; }
        public double AugmentedPressure { get; }
        public double AugmentedIndex { get; }
        public double ReferenceAge { get;  }
        public double PulseWaveVelocity { get;  }
    }
}