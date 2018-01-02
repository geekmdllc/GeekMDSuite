using GeekMDSuite.Core.LaboratoryData;

namespace GeekMDSuite.Core.Tools.Cardiology
{
    public interface IPooledCohortEquationParameters
    {
        IPatient Patient { get; set; }
        IBloodPressure BloodPressure { get; set; }
        IQuantitativeLab TotalCholesterol { get; set; }
        IQuantitativeLab HdlCholesterol { get; set; }
        bool HypertensionTreatment { get; set; }
        bool Smoker { get; set; }
        bool Diabetic { get; set; }
    }
}