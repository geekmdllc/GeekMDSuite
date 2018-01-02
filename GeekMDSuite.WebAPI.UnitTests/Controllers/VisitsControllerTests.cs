using System;
using System.Linq;
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
        [Fact]
        public void Add_GivenNewVisit_CreatesAVisitWithVisitGuid()
        {
            var visitDate = DateTime.Now;
            var unitOfWork = new FakeUnitOfWorkEmpty();
            var controller = new VisitsController(unitOfWork, new NewVisitService());
            
            controller.Post(new VisitEntity()
            {
                Date = visitDate,
                PatientGuid = Guid.NewGuid()
            });

            var addedVisits = unitOfWork.Visits.All().FirstOrDefault();
            
            Assert.True(addedVisits != null && addedVisits.Visit != Guid.Empty);
        }
        [Fact]
        public void GetByMedicalRecordNumber_GivenEmptyString_ReturnsBadRequestObjectResult()
        {
            var result = _controller.GetByMedicalRecordNumber(string.Empty);
            Assert.Equal(typeof(BadRequestResult), result.GetType());
        }
        
        [Fact]
        public void GetByMedicalRecordNumber_GivenRandomString_ReturnsNotFoundResult()
        {
            var result = _controller.GetByMedicalRecordNumber(Guid.NewGuid().ToString());
            Assert.Equal(typeof(NotFoundResult), result.GetType());
        }
        
        [Fact]
        public void GetByMedicalRecordNumber_GivenMedicalNumberThatExistsInContext_ReturnsOkObjectResult()
        {
            var result = _controller.GetByMedicalRecordNumber(FakeGeekMdSuiteContextBuilder.BruceWaynesMedicalRecordNumber);
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }
        
        [Fact]
        public void GetByName_GivenEmptyString_ReturnsBadRequestObjectResult()
        {
            var result = _controller.GetByName(string.Empty);
            Assert.Equal(typeof(BadRequestResult), result.GetType());
        }
        
        [Fact]
        public void GetByName_GivenRandomString_ReturnsNotFoundResult()
        {
            var result = _controller.GetByName(Guid.NewGuid().ToString());
            Assert.Equal(typeof(NotFoundResult), result.GetType());
        }
        
        [Fact]
        public void GetByName_GivenMedicalNumberThatExistsInContext_ReturnsOkObjectResult()
        {
            var result = _controller.GetByName("Bruce Wayne");
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }
        
        [Fact]
        public void GetByDateOfBirth_GivenAgeGreaterThan150Years_ReturnsBadRequestObjectResult()
        {
            var result = _controller.GetByDateOfBirth(DateTime.Now.AddYears(-151).ToShortDateString());
            Assert.Equal(typeof(BadRequestResult), result.GetType());
        }
        
        [Fact]
        public void GetByDateOfBirth_GivenPoorlyFormattedString_ReturnsBadRequestObjectResult()
        {
            var result = _controller.GetByDateOfBirth("111900");
            Assert.Equal(typeof(BadRequestResult), result.GetType());
        }
        
        [Fact]
        public void GetByDateOfBirth_GivenAgeOfZeroOrNegative_ReturnsBadRequestObjectResult()
        {
            var result = _controller.GetByDateOfBirth(DateTime.Now.AddYears(1).ToShortDateString());
            Assert.Equal(typeof(BadRequestResult), result.GetType());
        }
        
        [Fact]
        public void GetByDateOfBirth_GivenDateOfBirthNotInRepository_ReturnsNotFoundResult()
        {
            var result = _controller.GetByDateOfBirth(new DateTime(2000, 1, 1).ToShortDateString());
            Assert.Equal(typeof(NotFoundResult), result.GetType());
        }
        
        [Fact]
        public void GetByDateOfBirth_GivenDateOfBirthThatExistsInContext_ReturnsOkObjectResult()
        {
            var result = _controller.GetByDateOfBirth(new DateTime(1900, 1, 1).ToShortDateString());
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }
        
        [Fact]
        public void Post_GivenPatientWithEmptyGuid_ReturnsBadRequestObjectResul()
        {
            var result = _controller.Post(new VisitEntity()
            {
                Visit = Guid.Empty
            });
            
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public void Post_GivenNullPatient_ReturnsBadRequestObjectResult()
        {
            var result = _controller.Post(null);
            
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        public VisitsControllerTests()
        {
            _controller = new VisitsController(new FakeUnitOfWorkSeeded(), new NewVisitService());
        }

        private readonly VisitsController _controller;
    }
}