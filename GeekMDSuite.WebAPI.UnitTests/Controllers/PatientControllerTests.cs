using System;
using GeekMDSuite.Core;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Services;
using GeekMDSuite.WebAPI.Presentation.Controllers;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.StatusCodeResults;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Controllers
{
    public class PatientControllerTests
    {
        [Fact]
        public void Post_GivenMedicalRecordThatAlreadyExistsInRepository_ReturnsConflictRequest()
        {
            var result = _controller.Post(new PatientEntity()
            {
                Name = Name.Build("Joe", "Johson"),
                DateOfBirth = new DateTime(1977, 3, 2),
                MedicalRecordNumber = "12345"
            });
            
            Assert.Equal(typeof(ConflictResult), result.GetType());
        }
        
        [Fact]
        public void Post_GivenEmptyMedicalRecord_ReturnsBadRequestObjectResult()
        {
            var result = _controller.Post(new PatientEntity()
            {
                Name = Name.Build("Joe", "Johson"),
                DateOfBirth = new DateTime(1977, 3, 2),
                MedicalRecordNumber = string.Empty
            });
            
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }
        
        [Fact]
        public void Post_EmptyFirstName_ReturnsBadRequestObjectResult()
        {
            var result = _controller.Post(new PatientEntity()
            {
                Name = Name.Build(string.Empty, "Johson"),
                DateOfBirth = new DateTime(1977, 3, 2),
                MedicalRecordNumber = "12345"
            });
            
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }
        
        [Fact]
        public void Post_GivenEmptyLastName_ReturnsBadRequestObjectResult()
        {
            var result = _controller.Post(new PatientEntity()
            {
                Name = Name.Build("Joe", string.Empty),
                DateOfBirth = new DateTime(1977, 3, 2),
                MedicalRecordNumber = "12345"
            });
            
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }
        
        [Fact]
        public void Post_GivenDateTooOld_ReturnsBadRequestObjectResult()
        {
            var result = _controller.Post(new PatientEntity()
            {
                Name = Name.Build("Joe", "Johson"),
                DateOfBirth = DateTime.Now.AddYears(-151),
                MedicalRecordNumber = "12345"
            });
            
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }
        
        [Fact]
        public void Post_GivenDateTooNew_ReturnsBadRequestObjectResult()
        {
            var result = _controller.Post(new PatientEntity()
            {
                Name = Name.Build("Joe", "Johson"),
                DateOfBirth = DateTime.Now.AddYears(1),
                MedicalRecordNumber = "12345"
            });
            
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public void Post_GivenNullPatient_ReturnsBadREquestObjectResult()
        {
            var result = _controller.Post(null);
            
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }
        
        [Fact]
        public void Post_GivenProperlyPreparedPatient_ReturnsOkRequest()
        {
            var result = _controller.Post(new PatientEntity()
            {
                Name = Name.Build("Joe", "Johson"),
                DateOfBirth = new DateTime(1977, 3, 2),
                MedicalRecordNumber = Guid.NewGuid().ToString()
            });
            
            Assert.Equal(typeof(OkResult), result.GetType());
        }

        [Fact]
        public void GetByName_GivenEmptyString_ReturnsBadRequest()
        {
            var result = _controller.GetByName(string.Empty);
            
            Assert.Equal(typeof(BadRequestResult), result.GetType());
        }

        [Fact]
        public void GetByName_GivenNameNotInRepository_ReturnsNotfound()
        {
            var result = _controller.GetByName("Jar Jar Binks");
            
            Assert.Equal(typeof(NotFoundResult), result.GetType());
        }
        
        [Fact]
        public void GetByName_GivenNameInRepository_ReturnsOkObjectResult()
        {
            var result = _controller.GetByName("Bruce Wayne");
            
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }
        
        [Fact]
        public void GetByMrn_GivenMrnNotInRepository_ReturnsNotfound()
        {
            var result = _controller.GetByMrn(Guid.NewGuid().ToString());
            
            Assert.Equal(typeof(NotFoundResult), result.GetType());
        }
        
        [Fact]
        public void GetByMrn_GivenEmptyString_ReturnsBadRequst()
        {
            var result = _controller.GetByMrn(string.Empty);
            
            Assert.Equal(typeof(BadRequestResult), result.GetType());
        }
        
        [Fact]
        public void GetByMrn_GivenMrnInRepository_ReturnsOkObjectResult()
        {
            var result = _controller.GetByMrn("12345");
            
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public void GetByGuid_GivenEmptyGuid_ReturnsBadRequest()
        {
            var result = _controller.GetByGuid(Guid.Empty);
            
            Assert.Equal(typeof(BadRequestResult), result.GetType());
        }

        [Fact]
        public void GetByGuid_GivenGuidThatDoesNotExistInRepository_ReturnsNotFound()
        {
            var result = _controller.GetByGuid(Guid.NewGuid());
            
            Assert.Equal(typeof(NotFoundResult), result.GetType());
        }

        [Fact]
        public void GetByGuid_GivenProperGuid_ReturnsOkay()
        {
            var result = _controller.GetByGuid(FakeGeekMdSuiteContextBuilder.BruceWaynesGuid);
            
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }
        
        public PatientControllerTests()
        {
            _controller = new PatientsController(
                new FakeUnitOfWorkSeeded(), 
                new NewPatientService());
        }

        private readonly PatientsController _controller;
    }
}