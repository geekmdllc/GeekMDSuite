using System;
using GeekMDSuite.Analytics.Classification.CompositeScores;
using GeekMDSuite.Core.Builders;
using GeekMDSuite.Core.Builders.LaboratoryData;
using GeekMDSuite.Core.Models;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Classification.CompositeScores
{
    public class AscvdParametersBuilderTests
    {
        public AscvdParametersBuilderTests()
        {
            var bloodPressure = BloodPressure.Build(0, 0);
            var hdlCholesterol = Quantitative.Serum.HighDensityLipoprotein(0);
            var ldlCholesterol = Quantitative.Serum.LowDensityLipoprotein(0);
            var totalCholesterol = Quantitative.Serum.CholesterolTotal(0);
            var patient = PatientBuilder.Initialize().BuildWithoutModelValidation();
            _builder = AscvdParametersBuilder.Initialize()
                .SetBloodPressure(bloodPressure)
                .SetHdlCholesterol(hdlCholesterol)
                .SetLdlCholesterol(ldlCholesterol)
                .SetPatient(patient)
                .SetTotalCholesterol(totalCholesterol);
        }

        private readonly AscvdParametersBuilder _builder;

        [Fact]
        public void Build_GivenNulHLdlCholesterol_ThrowsMissingMethodException()
        {
            _builder.SetHdlCholesterol(null);
            Assert.Throws<MissingMethodException>(() => _builder.Build());
        }

        [Fact]
        public void Build_GivenNullBloodPressure_ThrowsMissingMethodException()
        {
            _builder.SetBloodPressure(null);
            Assert.Throws<MissingMethodException>(() => _builder.Build());
        }

        [Fact]
        public void Build_GivenNullLdlCholesterol_ThrowsMissingMethodException()
        {
            _builder.SetLdlCholesterol(null);
            Assert.Throws<MissingMethodException>(() => _builder.Build());
        }

        [Fact]
        public void Build_GivenNullPatient_ThrowsMissingMethodException()
        {
            _builder.SetPatient(null);
            Assert.Throws<MissingMethodException>(() => _builder.Build());
        }

        [Fact]
        public void Build_GivenNullTotalCholesterol_ThrowsMissingMethodException()
        {
            _builder.SetTotalCholesterol(null);
            Assert.Throws<MissingMethodException>(() => _builder.Build());
        }

        [Fact]
        public void Build_GivenValidParameters_Succeeds()
        {
            Assert.IsType<AscvdParameters>(_builder.Build());
        }

        [Fact]
        public void BuildWithoutModelValidation_GivenInvalidParameters_Succeeds()
        {
            _builder.SetBloodPressure(null);
            Assert.IsType<AscvdParameters>(_builder.BuildWithoutModelValidation());
        }
    }
}