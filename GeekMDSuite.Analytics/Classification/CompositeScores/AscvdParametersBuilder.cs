using System;
using System.ComponentModel;
using System.Text;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Classification.CompositeScores
{
    public class AscvdParametersBuilder : Builder<AscvdParametersBuilder, AscvdParameters>
    {
        public override AscvdParameters Build()
        {
            ValidatePreBuildState();
            return AscvdParameters.Build(_patient, _bloodPressure, _totalCholesterol, _ldlCholesterol, _hdlCholesterol);
        }

        public override AscvdParameters BuildWithoutModelValidation()
        {
            return new AscvdParameters()
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
            if (totalCholesterol.Type != QuantitativeLabType.CholesterolTotalSerum)
                throw new InvalidEnumArgumentException($"{nameof(totalCholesterol.Type)}. Should be {nameof(QuantitativeLabType.CholesterolTotalSerum)}");
            _totalCholesterol = totalCholesterol;
            return this;
        }

        public AscvdParametersBuilder SetLdlCholesterol(QuantitativeLab ldlCholesterol)
        {
            if (ldlCholesterol.Type != QuantitativeLabType.CholesterolTotalSerum)
                throw new InvalidEnumArgumentException($"{nameof(ldlCholesterol.Type)}. Should be {nameof(QuantitativeLabType.LowDensityLipoproteinSerum)}");
            _ldlCholesterol = ldlCholesterol;
            return this;
        }

        public AscvdParametersBuilder SetHdlCholesterol(QuantitativeLab hdlCholesterol)
        {
            if (hdlCholesterol.Type != QuantitativeLabType.CholesterolTotalSerum)
                throw new InvalidEnumArgumentException($"{nameof(hdlCholesterol.Type)}. Should be {nameof(QuantitativeLabType.HighDensityLipoproteinSerum)}");
            _hdlCholesterol = hdlCholesterol;
            return this;
        }
        
        private Patient _patient;
        private BloodPressure _bloodPressure;
        private QuantitativeLab _totalCholesterol;
        private QuantitativeLab _ldlCholesterol;
        private QuantitativeLab _hdlCholesterol;
        
        
        private void ValidatePreBuildState()
        {
            var builder = new StringBuilder();
            if (_bloodPressure == null) builder.Append(nameof(SetBloodPressure));
            if (_hdlCholesterol == null) builder.Append(nameof(SetHdlCholesterol));
            if (_ldlCholesterol == null) builder.Append(nameof(SetLdlCholesterol));
            if (_patient == null) builder.Append(nameof(SetPatient));
            if (_totalCholesterol == null) builder.Append(nameof(SetTotalCholesterol));

            var message = builder.ToString();
            if (string.IsNullOrWhiteSpace(message))
                throw new MissingMethodException(message);
        }
    }
}