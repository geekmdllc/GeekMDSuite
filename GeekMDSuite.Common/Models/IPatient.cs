using GeekMDSuite.Common.Tools;

namespace GeekMDSuite.Common.Models
{
    public interface IPatient
    {
        Gender Gender { get; }
        ILengthMeasurement Height { get; }
        IMassMeasurement BodyWeight { get; }
        Waist Waist { get; }
        Race Race { get; }
        IVitalSigns Vitals { get; }
    }
}