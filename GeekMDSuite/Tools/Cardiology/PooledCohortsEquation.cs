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
            _hdlCholesterol = hdlCholesterol;
            _totalCholesterol = totalCholesterol;
            _bloodPressure = bloodPressure;
            _patient = patient;
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            if (bloodPressure == null) throw new ArgumentNullException(nameof(bloodPressure));
            if (totalCholesterol == null) throw new ArgumentNullException(nameof(totalCholesterol));
            if (hdlCholesterol == null) throw new ArgumentNullException(nameof(hdlCholesterol));
            if (totalCholesterol.Type != QuantitativeLabType.CholesterolTotalSerum) 
                throw new InvalidEnumArgumentException($"{nameof(totalCholesterol)} should have an enum 'Type' of {nameof(QuantitativeLabType.CholesterolTotalSerum)}.");
            if (hdlCholesterol.Type != QuantitativeLabType.HighDensityLipoproteinSerum)
                throw new InvalidEnumArgumentException($"{nameof(hdlCholesterol)} should have an enum 'Type' of {nameof(QuantitativeLabType.HighDensityLipoproteinSerum)}.");

            _race = patient.Race;
            _age = patient.Age;
            _hypertensionTreatment = hypertensionTreatment;
            _smoker = smoker;
            _diabetic = diabetic;
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
        private double BaselineSurvival => GetBaselineSurvival();
        private double SumCoefficientValueProduct => GetSumOfCoefficientAndValueProduct();
        private double MeanSumCoefficientValueProduct => GetMeanSumCoefficentValueProduct();
    }
}