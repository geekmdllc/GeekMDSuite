using System;
using System.ComponentModel;
using GeekMDSuite.Analytics.Classification.CompositeScores;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Builders.LaboratoryData;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification.CompositeScores
{
    public class AscvdParametersTests
    {
        [Fact]
        public void Build_GivenNullPatient_ThrowsArgumentNullException()
        {
            _patient = null;
            Assert.Throws<ArgumentNullException>(
                () => AscvdParameters.Build(_patient, _bloodPressure, _totalCholesterol, _ldlCholesterol,
                    _hdlCholesterol));
        }
        
        [Fact]
        public void Build_GivenNullBloodPressure_ThrowsArgumentNullException()
        {
            _bloodPressure = null;
            Assert.Throws<ArgumentNullException>(
                () => AscvdParameters.Build(_patient, _bloodPressure, _totalCholesterol, _ldlCholesterol,
                    _hdlCholesterol));
        }
        
        [Fact]
        public void Build_GivenNullTotalCholesterol_ThrowsArgumentNullException()
        {
            _totalCholesterol = null;
            Assert.Throws<ArgumentNullException>(
                () => AscvdParameters.Build(_patient, _bloodPressure, _totalCholesterol, _ldlCholesterol,
                    _hdlCholesterol));
        }
        
        [Fact]
        public void Build_GivenNullLdlCholesterol_ThrowsArgumentNullException()
        {
            _ldlCholesterol = null;
            Assert.Throws<ArgumentNullException>(
                () => AscvdParameters.Build(_patient, _bloodPressure, _totalCholesterol, _ldlCholesterol,
                    _hdlCholesterol));
        }
        
        [Fact]
        public void Build_GivenNullHdlCholesterol_ThrowsArgumentNullException()
        {
            _hdlCholesterol = null;
            Assert.Throws<ArgumentNullException>(
                () => AscvdParameters.Build(_patient, _bloodPressure, _totalCholesterol, _ldlCholesterol,
                    _hdlCholesterol));
        }

        [Fact]
        public void Build_GivenTotalCholesterolWithWrongLabtype_ThrowsInvalidEnumArgumentException()
        {
            _totalCholesterol.Type = QuantitativeLabType.AlanineTransaminaseSerum;
            Assert.Throws<InvalidEnumArgumentException>(
                () => AscvdParameters.Build(_patient, _bloodPressure, _totalCholesterol, _ldlCholesterol,
                    _hdlCholesterol));
        }
        
        [Fact]
        public void Build_GivenLdlCholesterolWithWrongLabType_ThrowsInvalidEnumArgumentException()
        {
            _ldlCholesterol.Type = QuantitativeLabType.AlanineTransaminaseSerum;
            Assert.Throws<InvalidEnumArgumentException>(
                () => AscvdParameters.Build(_patient, _bloodPressure, _totalCholesterol, _ldlCholesterol,
                    _hdlCholesterol));
        }
        
        [Fact]
        public void Build_GivenHdlCholesterolWithWrongLabType_ThrowsInvalidEnumArgumentException()
        {
            _hdlCholesterol.Type = QuantitativeLabType.AlbuminSerum;
            Assert.Throws<InvalidEnumArgumentException>(
                () => AscvdParameters.Build(_patient, _bloodPressure, _totalCholesterol, _ldlCholesterol,
                    _hdlCholesterol));
        }

        public AscvdParametersTests()
        {
            _patient = PatientBuilder.Initialize().BuildWithoutModelValidation();
            _bloodPressure = BloodPressure.Build(0, 0);
            _totalCholesterol = Quantitative.Serum.CholesterolTotal(0);
            _ldlCholesterol = Quantitative.Serum.LowDensityLipoprotein(0);
            _hdlCholesterol = Quantitative.Serum.HighDensityLipoprotein(0);
        }
        private Patient _patient;
        private BloodPressure _bloodPressure;
        private QuantitativeLab _totalCholesterol;
        private QuantitativeLab _ldlCholesterol;
        private QuantitativeLab _hdlCholesterol;
    }
}