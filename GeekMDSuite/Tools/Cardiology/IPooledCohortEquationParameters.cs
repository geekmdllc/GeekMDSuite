using GeekMDSuite.LaboratoryData;

namespace GeekMDSuite.Tools.Cardiology
{
    public interface IPooledCohortEquationParameters
    {
        IPatient Patient { get; }
        IBloodPressure BloodPressure { get; }
        IQuantitativeLab TotalCholesterol { get; }
        IQuantitativeLab HdlCholesterol { get; }
        bool HypertensionTreatment { get; }
        bool Smoker { get; }
        bool Diabetic { get; }
    }
}