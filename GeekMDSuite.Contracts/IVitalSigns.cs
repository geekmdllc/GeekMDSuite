namespace GeekMDSuite.Contracts
{
    public interface IVitalSigns
    {
        int? SystolicBloodPressure { get; }
        int? DiastolicBloodPressure { get; }
        int? HeartRate { get; }
        int? OxygenSaturationPercentage { get; }
        int? RespiratoryRation { get; }
        double? Temperature { get; }
    }
}