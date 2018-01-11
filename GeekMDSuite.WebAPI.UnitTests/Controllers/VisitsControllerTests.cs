using System;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Services;
using GeekMDSuite.WebAPI.Presentation.Controllers;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Controllers
{
    public class VisitsControllerTests
    {
        public VisitsControllerTests()
        {
            _controller = new VisitController(new FakeUnitOfWorkSeeded(), new NewVisitService());
        }

        private readonly VisitController _controller;

        [Fact]
        public async Task Add_GivenNewVisit_CreatesAVisitWithVisitGuid()
        {
            var visitDate = DateTime.Now;
            var unitOfWork = new FakeUnitOfWorkEmpty();
            var controller = new VisitController(unitOfWork, new NewVisitService());

            await controller.Post(new VisitEntity
            {
                Date = visitDate,
                PatientGuid = Guid.NewGuid()
            });

            var addedVisits = (await unitOfWork.Visits.All()).FirstOrDefault();

            Assert.True(addedVisits != null && addedVisits.VisitId != Guid.Empty);
        }

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
        public async Task GetByMedicalRecordNumber_GivenEmptyString_ReturnsBadRequestObjectResult()
        {
            var result = await _controller.GetByMrn(string.Empty);
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByMedicalRecordNumber_GivenMedicalNumberThatExistsInContext_ReturnsOkObjectResult()
        {
            var result = await _controller.GetByMrn(FakeGeekMdSuiteContextBuilder.BruceWaynesMedicalRecordNumber);
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByMedicalRecordNumber_GivenRandomString_ReturnsNotFoundObjectResult()
        {
            var result = await _controller.GetByMrn(Guid.NewGuid().ToString());
            Assert.Equal(typeof(NotFoundObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByName_GivenEmptyString_ReturnsBadRequestObjectResult()
        {
            var result = await _controller.GetByName(string.Empty);
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByName_GivenMedicalNumberThatExistsInContext_ReturnsOkObjectResult()
        {
            var result = await _controller.GetByName("Bruce Wayne");
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByName_GivenRandomString_ReturnsNotFoundObjectResult()
        {
            var result = await _controller.GetByName(Guid.NewGuid().ToString());
            Assert.Equal(typeof(NotFoundObjectResult), result.GetType());
        }

        [Fact]
        public async Task Post_GivenNullPatient_ReturnsBadRequestObjectResult()
        {
            var result = await _controller.Post(null);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task Post_GivenPatientWithEmptyGuid_ReturnsBadRequestObjectResul()
        {
            var result = await _controller.Post(new VisitEntity
            {
                VisitId = Guid.Empty
            });

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }
    }
}