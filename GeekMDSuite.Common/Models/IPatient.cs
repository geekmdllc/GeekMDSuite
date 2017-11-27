namespace GeekMDSuite.Common.Models
{
    public interface IPatient
    {
        Gender Gender { get; }
        Height  Height { get; }
        Weight Weight { get; }
        Waist Waist { get; }
        Race Race { get; }
        IVitalSigns Vitals { get; }
    }
}