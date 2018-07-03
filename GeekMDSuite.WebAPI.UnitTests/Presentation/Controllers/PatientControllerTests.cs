using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Services;
using GeekMDSuite.WebAPI.Mapping;
using GeekMDSuite.WebAPI.Presentation.Controllers.PatientController;
using GeekMDSuite.WebAPI.Presentation.StatusCodeResults;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Xunit;
using IConfigurationProvider = Microsoft.Extensions.Configuration.IConfigurationProvider;

namespace GeekMDSuite.WebAPI.UnitTests.Presentation.Controllers
{
    public class PatientEntityControllerTests
    {
        public PatientEntityControllerTests()
        {
            _controller = new PatientController(
                new FakeUnitOfWorkSeeded(),
                new NewPatientService(),
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()))),
                new ErrorService(new ConfigurationRoot(new List<IConfigurationProvider>())));
        }

        private readonly PatientController _controller;

        [Fact]
        public async Task GetByGuid_GivenEmptyGuid_ReturnsBadRequest()
        {
            var result = await _controller.GetByGuid(Guid.Empty);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByGuid_GivenGuidThatDoesNotExistInRepository_ReturnsBadRequestObjectResult()
        {
            var result = await _controller.GetByGuid(Guid.NewGuid());

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByGuid_GivenProperGuid_ReturnsOkay()
        {
            var result = await _controller.GetByGuid(FakeGeekMdSuiteContextBuilder.BruceWaynesGuid);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public async Task Post_EmptyFirstName_ReturnsBadRequestObjectResult()
        {
            var result = await _controller.Post(new PatientStubFromUser
            {
                Name = new Name {First = string.Empty, Last = "Last"},
                DateOfBirth = new DateTime(1977, 3, 2),
                MedicalRecordNumber = "12345"
            });

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task Post_GivenDateTooNew_ReturnsBadRequestObjectResult()
        {
            var result = await _controller.Post(new PatientStubFromUser
            {
                Name = Name.Build("Joe", "Johson"),
                DateOfBirth = DateTime.Now.AddYears(1),
                MedicalRecordNumber = "12345"
            });

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task Post_GivenDateTooOld_ReturnsBadRequestObjectResult()
        {
            var result = await _controller.Post(new PatientStubFromUser
            {
                Name = Name.Build("Joe", "Johson"),
                DateOfBirth = DateTime.Now.AddYears(-151),
                MedicalRecordNumber = "12345"
            });

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task Post_GivenEmptyLastName_ReturnsBadRequestObjectResult()
        {
            var result = await _controller.Post(new PatientStubFromUser
            {
                Name = new Name {First = "First", Last = string.Empty},
                DateOfBirth = new DateTime(1977, 3, 2),
                MedicalRecordNumber = "12345"
            });

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task Post_GivenEmptyMedicalRecord_ReturnsBadRequestObjectResult()
        {
            var result = await _controller.Post(new PatientStubFromUser
            {
                Name = Name.Build("Joe", "Johson"),
                DateOfBirth = new DateTime(1977, 3, 2),
                MedicalRecordNumber = string.Empty
            });

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task Post_GivenMedicalRecordThatAlreadyExistsInRepository_ReturnsConflictRequest()
        {
            var result = await _controller.Post(new PatientStubFromUser
            {
                Name = Name.Build("Joe", "Johson"),
                DateOfBirth = new DateTime(1977, 3, 2),
                MedicalRecordNumber = "12345"
            });

            Assert.Equal(typeof(ConflictResult), result.GetType());
        }

        [Fact]
        public async Task Post_GivenNullPatientEntity_ReturnsBadREquestObjectResult()
        {
            var result = await _controller.Post(null);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task Post_GivenProperlyPreparedPatientEntity_ReturnsCreatedResult()
        {
            var result = await _controller.Post(new PatientStubFromUser
            {
                Name = Name.Build("Joe", "Johson"),
                DateOfBirth = new DateTime(1977, 3, 2),
                MedicalRecordNumber = Guid.NewGuid().ToString()
            });

            Assert.Equal(typeof(CreatedResult), result.GetType());
        }
    }
}