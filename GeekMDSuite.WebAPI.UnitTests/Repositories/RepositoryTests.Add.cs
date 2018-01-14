using System;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public partial class RepositoryTests
    {
        [Fact]
        public async Task Add_GivenAlreadyExistingEntity_ThrowsEntityNotUniqueExcetion()
        {
            var uow = new FakeUnitOfWorkSeeded();
            var audiogram = (await uow.Audiograms.All()).First();

            await Assert.ThrowsAsync<EntityNotUniqeException>(() => uow.EntityData<AudiogramEntity>().Add(audiogram));
        }

        [Fact]
        public async Task Add_GivenNull_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                _unitOfWorkSeeded.VisitData<AudiogramEntity>().Add(null));
        }

        [Fact]
        public async Task Add_GivenOneEntity_Succeeds()
        {
            var uow = new UnitOfWork(FakeGeekMdSuiteContextBuilder.EmptyContext);
            await uow.Audiograms.Add(new AudiogramEntity());
            await uow.Complete();

            var count = (await uow.VisitData<AudiogramEntity>().All()).Count();
            Assert.Equal(1, count);
        }
    }
}