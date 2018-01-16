using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Services;
using GeekMDSuite.WebAPI.Mapping;
using GeekMDSuite.WebAPI.Presentation;
using GeekMDSuite.WebAPI.Presentation.Controllers;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Xunit;
using IConfigurationProvider = Microsoft.Extensions.Configuration.IConfigurationProvider;

namespace GeekMDSuite.WebAPI.UnitTests.Presentation.Controllers
{
    public class VisitsControllerTests
    {
        private readonly IUnitOfWork _unitOfWork = new FakeUnitOfWorkSeeded();
        public VisitsControllerTests()
        {
            _controller = new VisitController(
                _unitOfWork, 
                new NewVisitService(), 
                new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()))),
                new UrlHelper(new ActionContext()),
                new ErrorService(new ConfigurationRoot(new List<IConfigurationProvider>())));
        }

        private readonly VisitController _controller;

        [Fact]
        public async Task Post_GivenNewVisit_CreatesAVisitWithVisitGuid()
        {
            await _controller.Post(new VisitStubFromUser
            {
                Date = DateTime.Now,
                PatientGuid = Guid.NewGuid()
            });

            var addedVisits = (await _unitOfWork.Visits.All()).FirstOrDefault();

            Assert.True(addedVisits != null && addedVisits.Guid != Guid.Empty);
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
            var result = await _controller.Post(new VisitStubFromUser
            {
                Guid = Guid.Empty
            });

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }
    }
}