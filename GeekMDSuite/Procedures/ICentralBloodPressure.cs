namespace GeekMDSuite.Procedures
{
    public interface ICentralBloodPressure
    {
        double SystolicPressure { get; }
        double PulsePressure { get; }
        double AugmentedPressure { get; }
        double AugmentedIndex { get; }
        double ReferenceAge { get; }
        double PulseWaveVelocity { get; }
    }
}