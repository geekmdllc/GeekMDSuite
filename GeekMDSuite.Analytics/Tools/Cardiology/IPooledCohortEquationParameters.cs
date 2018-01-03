using GeekMDSuite.Core;
using GeekMDSuite.Core.LaboratoryData;

namespace GeekMDSuite.Analytics.Tools.Cardiology
{
    public interface IPooledCohortEquationParameters
    {
        Patient Patient { get; set; }
        BloodPressure BloodPressure { get; set; }
        IQuantitativeLab TotalCholesterol { get; set; }
        IQuantitativeLab HdlCholesterol { get; set; }
        bool HypertensionTreatment { get; set; }
        bool Smoker { get; set; }
        bool Diabetic { get; set; }
    }
}