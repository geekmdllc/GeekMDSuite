using System.Linq;
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
        public void Delete_GivenAppropriateElement_ReturnsOkay()
        {
            var uow = new FakeUnitOfWorkSeeded();
            var audiogramId = uow.Audiograms.All().First().Id;

            var controller = new FakeEntityDataController(uow);

            var result = controller.Delete(audiogramId);

            Assert.Equal(typeof(OkResult), result.GetType());
        }

        [Fact]
        public void Delete_GivenElementThatDoesNotExistInRepository_ReturnsNotFound()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkSeeded());

            var result = controller.Delete(int.MaxValue);

            Assert.Equal(typeof(NotFoundObjectResult), result.GetType());
        }

        [Fact]
        public void Get_GivenEmptyUnitOfwork_ReturnsNotFoundObjectResult()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkEmpty());

            var result = controller.GetAll();

            Assert.Same(typeof(NotFoundObjectResult), result.GetType());
        }

        [Fact]
        public void Get_GivenSeededUnitOfWork_ReturnsOkObjectResult()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkSeeded());

            var result = controller.GetAll();

            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public void GetId_GivenIdInEmtpyUnitOfWorkContext_ReturnsNotFoundObjectResult()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkEmpty());

            var result = controller.GetByEntityId(1);

            Assert.Equal(typeof(NotFoundObjectResult), result.GetType());
        }

        [Fact]
        public void GetId_GivenIdInSeededUnitOfWorkContext_ReturnsOkObjectResult()
        {
            var uow = new FakeUnitOfWorkSeeded();
            var controller = new FakeEntityDataController(uow);
            var ag = uow.Audiograms.All().First();

            var result = controller.GetByEntityId(ag.Id);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public void Post_GivenEntity_ReturnsOkayResult()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkEmpty());

            var result = controller.Post(new AudiogramEntity());

            Assert.Equal(typeof(OkResult), result.GetType());
        }

        [Fact]
        public void Post_GivenNull_ReturnsNotFoundObjectResult()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkEmpty());

            var result = controller.Post(null);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public void Put_GivenAppropriateElement_ReturnsOkay()
        {
            var uow = new FakeUnitOfWorkSeeded();
            var audiogram = uow.Audiograms.All().First();
            audiogram.Left.F2000.Value = 150;

            var controller = new FakeEntityDataController(uow);

            var result = controller.Put(audiogram);

            Assert.Equal(typeof(OkResult), result.GetType());
        }

        [Fact]
        public void Put_GivenElementThatDoesNotExistInRepository_ReturnsNotFound()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkSeeded());

            var result = controller.Put(new AudiogramEntity {Id = int.MaxValue});

            Assert.Equal(typeof(NotFoundObjectResult), result.GetType());
        }

        [Fact]
        public void Put_GivenNull_ReturnsBadRequest()
        {
            var controller = new FakeEntityDataController(new FakeUnitOfWorkSeeded());

            var result = controller.Put(null);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }
    }
}