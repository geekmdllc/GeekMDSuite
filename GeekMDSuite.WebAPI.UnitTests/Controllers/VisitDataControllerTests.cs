using System;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.Presentation.Controllers;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Controllers
{
    public class VisitDataControllerTests
    {
        private class FakeVisitDataController : VisitDataController<AudiogramEntity>
        {
            public FakeVisitDataController(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }
        }

        [Fact]
        public async Task GetByPatient_GivenCorrectGuid_ReturnsOkObjectResult()
        {
            var controller = new FakeVisitDataController(new FakeUnitOfWorkSeeded());

            var result = await controller.GetByPatientGuid(FakeGeekMdSuiteContextBuilder.BruceWaynesGuid);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByPatient_GivenEmptyGuid_ReturnsBadRequest()
        {
            var controller = new FakeVisitDataController(new FakeUnitOfWorkSeeded());

            var result = await controller.GetByPatientGuid(Guid.Empty);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByPatient_GivenRandomGuid_ReturnsNotFound()
        {
            var controller = new FakeVisitDataController(new FakeUnitOfWorkSeeded());

            var result = await controller.GetByPatientGuid(Guid.NewGuid());

            Assert.Equal(typeof(NotFoundResult), result.GetType());
        }

        [Fact]
        public async Task GetByVisit_GivenCorrectGuid_ReturnsOkObjectResult()
        {
            var controller = new FakeVisitDataController(new FakeUnitOfWorkSeeded());

            var result = await controller.GetByVisitGuid(FakeGeekMdSuiteContextBuilder.BruceWaynesVisitGuid);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByVisit_GivenEmptyGuid_ReturnsBadRequest()
        {
            var controller = new FakeVisitDataController(new FakeUnitOfWorkSeeded());

            var result = await controller.GetByVisitGuid(Guid.Empty);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task GetByVisit_GivenRandomGuid_ReturnsNotFound()
        {
            var controller = new FakeVisitDataController(new FakeUnitOfWorkSeeded());

            var result = await controller.GetByVisitGuid(Guid.NewGuid());

            Assert.Equal(typeof(NotFoundResult), result.GetType());
        }
    }
}