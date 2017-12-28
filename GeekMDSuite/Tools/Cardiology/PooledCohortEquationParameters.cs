using GeekMDSuite.LaboratoryData;

namespace GeekMDSuite.Tools.Cardiology
{
    public class PooledCohortEquationParameters : IPooledCohortEquationParameters
    {
        public IPatient Patient { get; }
        public IBloodPressure BloodPressure { get; }
        public IQuantitativeLab TotalCholesterol { get; }
        public IQuantitativeLab HdlCholesterol { get; }
        public bool HypertensionTreatment { get; }
        public bool Smoker { get; }
        public bool Diabetic { get;}

        internal static PooledCohortEquationParameters Build(IPatient patient, IBloodPressure bloodPressure,
            IQuantitativeLab totalCholesterol, IQuantitativeLab hdlCholesterol,
            bool hypertensionTreatment = false, bool smoker = false, bool diabetic = false)
        {
            return new PooledCohortEquationParameters(patient, bloodPressure, totalCholesterol, hdlCholesterol,
                hypertensionTreatment, smoker, diabetic);   
        }

        private PooledCohortEquationParameters(IPatient patient, IBloodPressure bloodPressure, 
            IQuantitativeLab totalCholesterol, IQuantitativeLab hdlCholesterol, 
            bool hypertensionTreatment, bool smoker, bool diabetic)
        {
            Patient = patient;
            BloodPressure = bloodPressure;
            TotalCholesterol = totalCholesterol;
            HdlCholesterol = hdlCholesterol;
            HypertensionTreatment = hypertensionTreatment;
            Smoker = smoker;
            Diabetic = diabetic;
        }
    }
}