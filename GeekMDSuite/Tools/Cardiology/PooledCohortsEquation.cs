using System;
using System.ComponentModel;
using GeekMDSuite.LaboratoryData;

namespace GeekMDSuite.Tools.Cardiology
{
    public partial class PooledCohortsEquation
    {

        public PooledCohortsEquation(IPatient patient, IBloodPressure bloodPressure, 
            IQuantitativeLab totalCholesterol, IQuantitativeLab hdlCholesterol,
            bool hypertensionTreatment = false, bool smoker = false, bool diabetic = false)
        {
            _hdlCholesterol = hdlCholesterol ?? throw new ArgumentNullException(nameof(hdlCholesterol));
            _totalCholesterol = totalCholesterol ?? throw new ArgumentNullException(nameof(totalCholesterol));
            _bloodPressure = bloodPressure ?? throw new ArgumentNullException(nameof(bloodPressure));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            _race = patient.Race;
            _age = patient.Age;
            _hypertensionTreatment = hypertensionTreatment;
            _smoker = smoker;
            _diabetic = diabetic;
            
            if (totalCholesterol.Type != QuantitativeLabType.CholesterolTotalSerum) 
                throw new InvalidEnumArgumentException($"{nameof(totalCholesterol)} should have an enum 'Type' of {nameof(QuantitativeLabType.CholesterolTotalSerum)}.");
            if (hdlCholesterol.Type != QuantitativeLabType.HighDensityLipoproteinSerum)
                throw new InvalidEnumArgumentException($"{nameof(hdlCholesterol)} should have an enum 'Type' of {nameof(QuantitativeLabType.HighDensityLipoproteinSerum)}.");
        }
                
        private readonly IPatient _patient;
        private readonly IBloodPressure _bloodPressure;
        private readonly IQuantitativeLab _totalCholesterol;
        private readonly IQuantitativeLab _hdlCholesterol;
        private readonly Race _race;
        private readonly int _age;
        private readonly bool _hypertensionTreatment;
        private readonly bool _smoker;
        private readonly bool _diabetic;
    }
}