namespace GeekMDSuite.Core.Procedures
{
    public interface ICentralBloodPressure
    {
        double SystolicPressure { get; set; }
        double PulsePressure { get; set; }
        double AugmentedPressure { get; set; }
        double AugmentedIndex { get; set; }
        double ReferenceAge { get; set; }
        double PulseWaveVelocity { get; set; }
    }
}