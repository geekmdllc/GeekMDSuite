using System;
using System.Collections.Generic;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.LaboratoryData.Builder;

namespace GeekMDSuite.Tools.Cardiology
{
    public class PooledCohortEquationParametersBuilder : IBuilder<PooledCohortEquationParameters>
    {
        private IPatient _patient;
        private IBloodPressure _bloodPressure;
        private IQuantitativeLab _totalCholesterol;
        private IQuantitativeLab _hdlCholesterol;
        private bool _hypertensionTreatment;
        private bool _smoker;
        private bool _diabetic;

        public static PooledCohortEquationParametersBuilder Initialize() => new PooledCohortEquationParametersBuilder();

        public PooledCohortEquationParametersBuilder SetPatient(IPatient patient)
        {
            _patient = patient;
            return this;
        }

        public PooledCohortEquationParametersBuilder SetBloodPressure(int systolic, int diastolic)
        {
            _bloodPressure = BloodPressure.Build(systolic, diastolic);
            return this;
        }

        public PooledCohortEquationParametersBuilder SetBloodPressure(IBloodPressure bloodPressure)
        {
            _bloodPressure = bloodPressure;
            return this;
        }

        public PooledCohortEquationParametersBuilder SetTotalCholesterol(double result)
        {
            _totalCholesterol = Quantitative.Serum.CholesterolTotal(result);
            return this;
        }
        
        public PooledCohortEquationParametersBuilder SetHdlCholesterol(double result)
        {
            _hdlCholesterol = Quantitative.Serum.HighDensityLipoprotein(result);
            return this;
        }

        public PooledCohortEquationParametersBuilder ConfirmOnAntiHypertensiveMedication(bool confirm = true)
        {
            _hypertensionTreatment = confirm;
            return this;
        }
        
        public PooledCohortEquationParametersBuilder ConfirmDiabetic(bool confirm = true)
        {
            _diabetic = confirm;
            return this;
        }
        
        public PooledCohortEquationParametersBuilder ConfirmSmoker(bool confirm = true)
        {
            _smoker = confirm;
            return this;
        }

        public PooledCohortEquationParameters Build()
        {
            VerifyPreBuildState();
            return PooledCohortEquationParameters.Build(_patient, _bloodPressure, _totalCholesterol, _hdlCholesterol,
                _hypertensionTreatment, _smoker, _diabetic);
        }
        
        private void VerifyPreBuildState()
        {
            var messages = new List<string>();
            if (_patient == null) messages.Add(nameof(SetPatient));
            if (_bloodPressure == null) messages.Add(nameof(SetBloodPressure));
            if (_totalCholesterol == null) messages.Add(nameof(SetTotalCholesterol));
            if (_hdlCholesterol == null) messages.Add(nameof(SetHdlCholesterol));
            
            if (messages.Count > 0) throw new MissingMethodException(string.Join(", ", messages));
        }
    }
}