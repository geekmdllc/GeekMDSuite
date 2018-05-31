using System;
using AutoMapper;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using GeekMDSuite.WebAPI.Presentation.StubModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Mapping
{
    public partial class MappingConfigurationTests
    {
        [Fact]
        public void MappingConfiguration_MapsPatientEntityToPatientStub_Successfully()
        {
            var entity = new PatientEntity
            {
                PatientGuid = new Guid(),
                Id = 0
            };

            var stub = _mapper.Map<PatientEntity, PatientStub>(entity);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PatientStub>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsPatientStubFromUserToPatientEntity_Successfully()
        {
            var stubFromUser = new PatientStubFromUser
            {
                PatientGuid = new Guid()
            };

            var stub = _mapper.Map<PatientStubFromUser, PatientEntity>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PatientEntity>(stub);
        }

        [Fact]
        public void MappingConfiguration_MapsPatientStubFromUserToPatientStub_Successfully()
        {
            var stubFromUser = new PatientStubFromUser
            {
                PatientGuid = new Guid()
            };

            var stub = _mapper.Map<PatientStubFromUser, PatientStub>(stubFromUser);
            Mapper.Reset();
            Assert.NotNull(stub);
            Assert.IsType<PatientStub>(stub);
        }
    }
}