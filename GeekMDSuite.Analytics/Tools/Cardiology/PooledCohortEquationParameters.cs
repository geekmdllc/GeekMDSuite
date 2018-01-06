using System;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Tools.Cardiology
{
    public class PooledCohortEquationParameters
    {
        internal PooledCohortEquationParameters()
        {
            Patient = new Patient();
            BloodPressure = new BloodPressure();
            TotalCholesterol = new QuantitativeLab();
            HdlCholesterol = new QuantitativeLab();
        }

        private PooledCohortEquationParameters(
            Patient patient, 
            BloodPressure bloodPressure, 
            QuantitativeLab totalCholesterol, 
            QuantitativeLab hdlCholesterol) : this()
        {
            Patient = patient ?? throw new ArgumentNullException(nameof(patient));
            BloodPressure = bloodPressure ?? throw new ArgumentNullException(nameof(bloodPressure));
            TotalCholesterol = totalCholesterol ?? throw new ArgumentNullException(nameof(totalCholesterol));
            HdlCholesterol = hdlCholesterol ?? throw new ArgumentNullException(nameof(hdlCholesterol));
            HypertensionTreatment = patient.Comorbidities.Contains(ChronicDisease.HypertensionTreated);
            Smoker = patient.Comorbidities.Contains(ChronicDisease.TobaccoSmoker);
            Diabetic = patient.Comorbidities.Contains(ChronicDisease.Diabetes);
        }
        
        public Patient Patient { get; set; }
        public BloodPressure BloodPressure { get; set; }
        public QuantitativeLab TotalCholesterol { get; set; }
        public QuantitativeLab HdlCholesterol { get; set; }
        public bool HypertensionTreatment { get; set; }
        public bool Smoker { get; set; }
        public bool Diabetic { get; set; }

        internal static PooledCohortEquationParameters Build(
            Patient patient, 
            BloodPressure bloodPressure,
            QuantitativeLab totalCholesterol, 
            QuantitativeLab hdlCholesterol)
        {
            return new PooledCohortEquationParameters(patient, bloodPressure, totalCholesterol, hdlCholesterol);   
        }
    }
}