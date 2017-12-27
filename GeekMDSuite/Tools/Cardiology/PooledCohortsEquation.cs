using System;
using GeekMDSuite.LaboratoryData;

namespace GeekMDSuite.Tools.Cardiology
{
    public partial class PooledCohortsEquation
    {
        public PooledCohortsEquation(IPatient patient, IBloodPressure bloodPressure, 
            QuantitativeLab totalCholesterol, QuantitativeLab hdlCholesterol,
            bool hypertensionTreatment = false, bool smoker = false, bool diabetic = false)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            if (bloodPressure == null) throw new ArgumentNullException(nameof(bloodPressure));
            
            _gender = patient.Gender;
            _race = patient.Race;
            _age = patient.Age;
            _systolicBloodPressure = bloodPressure.Systolic;
            _totalCholesterol = totalCholesterol.Result;
            _hdlCholesterol = hdlCholesterol.Result;
            _hypertensionTreatment = hypertensionTreatment;
            _smoker = smoker;
            _diabetic = diabetic;
        }
    }
}