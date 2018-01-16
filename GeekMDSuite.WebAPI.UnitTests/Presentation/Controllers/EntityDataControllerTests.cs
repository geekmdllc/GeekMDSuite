﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Services;
using GeekMDSuite.WebAPI.Mapping;
using GeekMDSuite.WebAPI.Presentation;
using GeekMDSuite.WebAPI.Presentation.Controllers;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Xunit;
using IConfigurationProvider = Microsoft.Extensions.Configuration.IConfigurationProvider;

namespace GeekMDSuite.WebAPI.UnitTests.Presentation.Controllers
{
    public class EntityDataControllerTests
    {
        [Fact]
        public async Task Delete_GivenAppropriateElement_ReturnsOkay()
        {
            var uow = new FakeUnitOfWorkSeeded();
            var audiogramId = (await uow.Audiograms.All()).First().Id;

            var controller = new FakeEntityDataController(uow);

            var result = await controller.Delete(audiogramId);

            Assert.Equal(typeof(OkResult), result.GetType());
        }

        [Fact]
        public async Task Delete_GivenElementThatDoesNotExistInRepository_ReturnsNotFound()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkSeeded());

            var result = await controller.Delete(int.MaxValue);

            Assert.Equal(typeof(NotFoundObjectResult), result.GetType());
        }

        [Fact]
        public async Task Post_GivenEntity_ReturnsOkayResult()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkEmpty());

            var result = await controller.Post(new AudiogramStubFromUser());

            Assert.Equal(typeof(OkResult), result.GetType());
        }

        [Fact]
        public async Task Post_GivenNull_ReturnsNotFoundObjectResult()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkEmpty());

            var result = await controller.Post(null);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public async Task Put_GivenAppropriateElement_ReturnsOkay()
        {
            var uow = new FakeUnitOfWorkSeeded();
            var audiogram = (await uow.Audiograms.All()).First();
            audiogram.Left.F2000.Value = 150;

            var controller = new FakeEntityDataController(uow);

            var result = await controller.Put(Mapper.Map<AudiogramEntity, AudiogramStubFromUser>(audiogram));

            Assert.Equal(typeof(OkResult), result.GetType());
        }

        [Fact]
        public async Task Put_GivenElementThatDoesNotExistInRepository_ReturnsNotFound()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkSeeded());

            var result = await controller.Put(new AudiogramStubFromUser {Id = int.MaxValue});

            Assert.Equal(typeof(NotFoundObjectResult), result.GetType());
        }

        [Fact]
        public async Task Put_GivenNull_ReturnsBadRequest()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkSeeded());

            var result = await controller.Put(null);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }
        
        private static readonly IMapper Mapper = new Mapper(new MapperConfiguration(configure => configure.AddProfile(new MappingProfile())));
        
        public EntityDataControllerTests()
        {
        }
        
        private class FakeEntityDataController : EntityDataController<AudiogramEntity,  AudiogramStubFromUser>
        {
            public FakeEntityDataController(IUnitOfWork unitOfWork, IMapper mapper, IErrorService errorService) : base(unitOfWork, mapper, errorService)
            {
                
            }

            public FakeEntityDataController(IUnitOfWork unitOfWork) : this(
                unitOfWork, 
                EntityDataControllerTests.Mapper, 
                new ErrorService(new ConfigurationRoot(new List<IConfigurationProvider>())))
            {

            }
        }
    }
}