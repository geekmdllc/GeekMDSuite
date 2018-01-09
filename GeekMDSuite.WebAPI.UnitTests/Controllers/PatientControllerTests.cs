using System;
using System.Threading.Tasks;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Services;
using GeekMDSuite.WebAPI.Presentation.Controllers;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.StatusCodeResults;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Controllers
{
    public class PatientEntityControllerTests
    {
        public PatientEntityControllerTests()
        {
            _controller = new PatientController(
                new FakeUnitOfWorkSeeded(),
                new NewPatientService());
        }

        private readonly PatientController _controller;

        [Fact]
        public async Task GetByDateOfBirth_GivenAgeGreaterThan150Years_ReturnsBadRequestObjectResult()
        {
            var result = await _controller.GetByDateOfBirth(DateTime.Now.AddYears(-151).ToShortDateString());
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByDateOfBirth_GivenAgeOfZeroOrNegative_ReturnsBadRequestObjectResult()
        {
            var result = await _controller.GetByDateOfBirth(DateTime.Now.AddYears(1).ToShortDateString());
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByDateOfBirth_GivenDateOfBirthNotInRepository_ReturnsNotFoundObjectResult()
        {
            var result = await _controller.GetByDateOfBirth(new DateTime(2000, 1, 1).ToShortDateString());
            Assert.Equal(typeof(NotFoundObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByDateOfBirth_GivenDateOfBirthThatExistsInContext_ReturnsOkObjectResult()
        {
            var result = await _controller.GetByDateOfBirth(new DateTime(1900, 1, 1).ToShortDateString());
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByDateOfBirth_GivenPoorlyFormattedString_ReturnsBadRequestObjectResult()
        {
            var result = await _controller.GetByDateOfBirth("111900");
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByGuid_GivenEmptyGuid_ReturnsBadRequest()
        {
            var result = await _controller.GetByGuid(Guid.Empty);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByGuid_GivenGuidThatDoesNotExistInRepository_ReturnsNotFound()
        {
            var result = await _controller.GetByGuid(Guid.NewGuid());

            Assert.Equal(typeof(NotFoundObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByGuid_GivenProperGuid_ReturnsOkay()
        {
            var result = await _controller.GetByGuid(FakeGeekMdSuiteContextBuilder.BruceWaynesGuid);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByMrn_GivenEmptyString_ReturnsBadRequst()
        {
            var result = await _controller.GetByMrn(string.Empty);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByMrn_GivenMrnInRepository_ReturnsOkObjectResult()
        {
            var result = await _controller.GetByMrn("12345");

            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByMrn_GivenMrnNotInRepository_ReturnsNotfound()
        {
            var result = await _controller.GetByMrn(Guid.NewGuid().ToString());

            Assert.Equal(typeof(NotFoundObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByName_GivenEmptyString_ReturnsBadRequest()
        {
            var result = await _controller.GetByName(string.Empty);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByName_GivenNameInRepository_ReturnsOkObjectResult()
        {
            var result = await _controller.GetByName("Bruce Wayne");

            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByName_GivenNameNotInRepository_ReturnsNotfound()
        {
            var result = await _controller.GetByName("Jar Jar Binks");

            Assert.Equal(typeof(NotFoundObjectResult), result.GetType());
        }

        [Fact]
        public async Task Post_EmptyFirstName_ReturnsBadRequestObjectResult()
        {
            var result = await _controller.Post(new PatientEntity
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
            var result = await _controller.Post(new PatientEntity
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
            var result = await _controller.Post(new PatientEntity
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
            var result = await _controller.Post(new PatientEntity
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
            var result = await _controller.Post(new PatientEntity
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
            var result = await _controller.Post(new PatientEntity
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
        public async Task Post_GivenProperlyPreparedPatientEntity_ReturnsOkRequest()
        {
            var result = await _controller.Post(new PatientEntity
            {
                Name = Name.Build("Joe", "Johson"),
                DateOfBirth = new DateTime(1977, 3, 2),
                MedicalRecordNumber = Guid.NewGuid().ToString()
            });

            Assert.Equal(typeof(OkResult), result.GetType());
        }
    }
}