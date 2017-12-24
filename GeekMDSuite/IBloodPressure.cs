namespace GeekMDSuite
{
    public interface IBloodPressure
    {
        int Systolic { get; }
        int Diastolic { get; }
        bool OrganDamage { get; }
    }
}