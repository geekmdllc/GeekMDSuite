using System;
using System.Text;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Classification.CompositeScores
{
    public class AscvdParametersBuilder : Builder<AscvdParametersBuilder, AscvdParameters>
    {
        private BloodPressure _bloodPressure;
        private QuantitativeLab _hdlCholesterol;
        private QuantitativeLab _ldlCholesterol;

        private Patient _patient;
        private QuantitativeLab _totalCholesterol;

        public override AscvdParameters Build()
        {
            ValidatePreBuildState();
            return AscvdParameters.Build(_patient, _bloodPressure, _totalCholesterol, _ldlCholesterol, _hdlCholesterol);
        }

        public override AscvdParameters BuildWithoutModelValidation()
        {
            return new AscvdParameters
            {
                Patient = _patient,
                BloodPressure = _bloodPressure,
                TotalCholesterol = _totalCholesterol,
                LdlCholesterol = _ldlCholesterol,
                HdlCholesterol = _hdlCholesterol
            };
        }

        public AscvdParametersBuilder SetPatient(Patient patient)
        {
            _patient = patient;
            return this;
        }

        public AscvdParametersBuilder SetBloodPressure(BloodPressure bloodPressure)
        {
            _bloodPressure = bloodPressure;
            return this;
        }

        public AscvdParametersBuilder SetTotalCholesterol(QuantitativeLab totalCholesterol)
        {
            _totalCholesterol = totalCholesterol;
            return this;
        }

        public AscvdParametersBuilder SetLdlCholesterol(QuantitativeLab ldlCholesterol)
        {
            _ldlCholesterol = ldlCholesterol;
            return this;
        }

        public AscvdParametersBuilder SetHdlCholesterol(QuantitativeLab hdlCholesterol)
        {
            _hdlCholesterol = hdlCholesterol;
            return this;
        }


        private void ValidatePreBuildState()
        {
            var builder = new StringBuilder();
            if (_bloodPressure == null) builder.Append(nameof(SetBloodPressure));
            if (_hdlCholesterol == null) builder.Append(nameof(SetHdlCholesterol));
            if (_ldlCholesterol == null) builder.Append(nameof(SetLdlCholesterol));
            if (_patient == null) builder.Append(nameof(SetPatient));
            if (_totalCholesterol == null) builder.Append(nameof(SetTotalCholesterol));

            var message = builder.ToString();
            if (!string.IsNullOrWhiteSpace(message))
                throw new MissingMethodException(message);
        }
    }
}