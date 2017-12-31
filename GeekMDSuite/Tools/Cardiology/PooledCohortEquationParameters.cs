using GeekMDSuite.LaboratoryData;

namespace GeekMDSuite.Tools.Cardiology
{
    public class PooledCohortEquationParameters : IPooledCohortEquationParameters
    {
        public PooledCohortEquationParameters()
        {
            Patient = new Patient();
            BloodPressure = new BloodPressure();
            TotalCholesterol = new QuantitativeLab();
            HdlCholesterol = new QuantitativeLab();
        }

        private PooledCohortEquationParameters(
            IPatient patient, 
            IBloodPressure bloodPressure, 
            IQuantitativeLab totalCholesterol, 
            IQuantitativeLab hdlCholesterol, 
            bool hypertensionTreatment, 
            bool smoker, 
            bool diabetic) : this()
        {
            Patient = patient;
            BloodPressure = bloodPressure;
            TotalCholesterol = totalCholesterol;
            HdlCholesterol = hdlCholesterol;
            HypertensionTreatment = hypertensionTreatment;
            Smoker = smoker;
            Diabetic = diabetic;
        }
        
        public IPatient Patient { get; set; }
        public IBloodPressure BloodPressure { get; set; }
        public IQuantitativeLab TotalCholesterol { get; set; }
        public IQuantitativeLab HdlCholesterol { get; set; }
        public bool HypertensionTreatment { get; set; }
        public bool Smoker { get; set; }
        public bool Diabetic { get; set; }

        internal static PooledCohortEquationParameters Build(
            IPatient patient, 
            IBloodPressure bloodPressure,
            IQuantitativeLab totalCholesterol, 
            IQuantitativeLab hdlCholesterol,
            bool hypertensionTreatment = false, 
            bool smoker = false, 
            bool diabetic = false)
        {
            return new PooledCohortEquationParameters(patient, bloodPressure, totalCholesterol, hdlCholesterol,
                hypertensionTreatment, smoker, diabetic);   
        }
    }
}