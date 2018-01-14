using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.Presentation.Controllers;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Controllers
{
    public class EntityDataControllerTests
    {
        private class FakeEntityDataController : EntityDataController<AudiogramEntity>
        {
            public FakeEntityDataController(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }
        }

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

            var result = await controller.Post(new AudiogramEntity());

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

            var result = await controller.Put(audiogram);

            Assert.Equal(typeof(OkResult), result.GetType());
        }

        [Fact]
        public async Task Put_GivenElementThatDoesNotExistInRepository_ReturnsNotFound()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkSeeded());

            var result = await controller.Put(new AudiogramEntity {Id = int.MaxValue});

            Assert.Equal(typeof(NotFoundObjectResult), result.GetType());
        }

        [Fact]
        public async Task Put_GivenNull_ReturnsBadRequest()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkSeeded());

            var result = await controller.Put(null);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }
    }
}