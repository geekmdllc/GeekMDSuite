using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Services;
using GeekMDSuite.WebAPI.Mapping;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;
using IConfigurationProvider = Microsoft.Extensions.Configuration.IConfigurationProvider;

namespace GeekMDSuite.WebAPI.UnitTests.Presentation.Controllers
{
    public class BloodPressureControllerTests
    {
        private readonly BloodPressureController _bloodPressureController;

        public BloodPressureControllerTests()
        {
            _bloodPressureController = new BloodPressureController(
                new FakeUnitOfWorkSeeded(),
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()))),
                new ErrorService(new ConfigurationRoot(new List<IConfigurationProvider>())));

            var mock = new Mock<IUrlHelper>();
            mock.Setup(m => m.Action<BloodPressureController>(a => a.GetById(With.No<int>()))).Returns("mock");
            _bloodPressureController.Url = mock.Object;
        }

        [Fact]
        public async Task GetById_GivenIdThatExistsInDatabase_ReturnsOkResult()
        {
            var result = await _bloodPressureController.GetById(1);
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }
    }
}