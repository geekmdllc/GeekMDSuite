using System;
using System.ComponentModel;
using GeekMDSuite.LaboratoryData;

namespace GeekMDSuite.Tools.Cardiology
{
    public partial class PooledCohortsEquation
    {
        public static PooledCohortsEquation Initialize(IPooledCohortEquationParameters parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            
            return new PooledCohortsEquation(parameters);
        }
        
        private PooledCohortsEquation(IPooledCohortEquationParameters parameters)
        {
            _hdlCholesterol = parameters.HdlCholesterol ?? throw new ArgumentNullException(nameof(parameters.HdlCholesterol));
            _totalCholesterol = parameters.TotalCholesterol ?? throw new ArgumentNullException(nameof(parameters.TotalCholesterol));
            _bloodPressure = parameters.BloodPressure ?? throw new ArgumentNullException(nameof(parameters.BloodPressure));
            _patient = parameters.Patient ?? throw new ArgumentNullException(nameof(parameters.Patient));
            _hypertensionTreatment = parameters.HypertensionTreatment;
            _smoker = parameters.Smoker;
            _diabetic = parameters.Diabetic;
            
            if (parameters.TotalCholesterol.Type != QuantitativeLabType.CholesterolTotalSerum) 
                throw new InvalidEnumArgumentException($"{nameof(parameters.TotalCholesterol)} should have an enum 'Type' of {nameof(QuantitativeLabType.CholesterolTotalSerum)}.");
            if (parameters.HdlCholesterol.Type != QuantitativeLabType.HighDensityLipoproteinSerum)
                throw new InvalidEnumArgumentException($"{nameof(parameters.HdlCholesterol)} should have an enum 'Type' of {nameof(QuantitativeLabType.HighDensityLipoproteinSerum)}.");
        }
                
        private readonly IPatient _patient;
        private readonly IBloodPressure _bloodPressure;
        private readonly IQuantitativeLab _totalCholesterol;
        private readonly IQuantitativeLab _hdlCholesterol;
        private readonly bool _hypertensionTreatment;
        private readonly bool _smoker;
        private readonly bool _diabetic;
    }
}