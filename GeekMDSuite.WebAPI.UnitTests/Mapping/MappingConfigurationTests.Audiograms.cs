using System;
using AutoMapper;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using GeekMDSuite.WebAPI.Presentation.StubModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Mapping
{
    public partial class MappingConfigurationTests
    {
        [Fact]
        public void MappingConfiguration_MapsAudiogramEntityToAudiogramStub_Successfully()
        {
            var ag = new AudiogramEntity
            {
                VisitGuid = new Guid(),
                Id = 0,
            };

            var agStub = _mapper.Map<AudiogramEntity, AudiogramStub>(ag);
            Mapper.Reset();
            Assert.NotNull(agStub);
            Assert.IsType<AudiogramStub>(agStub);
        }

        [Fact]
        public void MappingConfiguration_MapsAudiogramStubFromUserToAudiogramEntity_Successfully()
        {
            var agStubFromUser = new AudiogramStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0,
            };

            var ag = _mapper.Map<AudiogramStubFromUser, Audiogram>(agStubFromUser);
            Mapper.Reset();
            Assert.NotNull(ag);
            Assert.IsType<Audiogram>(ag);
        }

        [Fact]
        public void MappingConfiguration_MapsAudiogramStubFromUserToAudiogramStub_Successfully()
        {
            var agStubeFromUser = new AudiogramStubFromUser
            {
                VisitGuid = new Guid(),
                Id = 0,
            };

            var agStub = _mapper.Map<AudiogramStubFromUser, AudiogramStub>(agStubeFromUser);
            Mapper.Reset();
            Assert.NotNull(agStub);
            Assert.IsType<AudiogramStub>(agStub);
        }
    }
}