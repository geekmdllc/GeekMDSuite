using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Services;
using GeekMDSuite.WebAPI.Mapping;
using GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using IConfigurationProvider = Microsoft.Extensions.Configuration.IConfigurationProvider;

namespace GeekMDSuite.WebAPI.UnitTests.Presentation.Controllers
{
    public class BloodPressureControllerTests
    {
        private readonly BloodPressuresController _bloodPressuresController;

        public BloodPressureControllerTests()
        {
            _bloodPressuresController = new BloodPressuresController(
                new FakeUnitOfWorkSeeded(),
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()))),
                new ErrorService(new ConfigurationRoot(new List<IConfigurationProvider>())));

            var mock = new Mock<IUrlHelper>();
            mock.Setup(m => m.Action<BloodPressuresController>(a => a.GetById(With.No<int>()))).Returns("mock");
            _bloodPressuresController.Url = mock.Object;
        }

        [Fact]
        public async Task GetById_GivenIdThatExistsInDatabase_ReturnsOkResult()
        {
            var result = await _bloodPressuresController.GetById(1);
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }
    }
}