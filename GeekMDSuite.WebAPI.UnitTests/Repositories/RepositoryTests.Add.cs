using System;
using System.Linq;
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
        public void Add_GivenAlreadyExistingEntity_ThrowsEntityNotUniqueExcetion()
        {
            var uow = new FakeUnitOfWorkSeeded();
            var audiogram = uow.Audiograms.All().First();

            Assert.Throws<EntityNotUniqeException>(() => uow.EntityData<AudiogramEntity>().Add(audiogram));
        }

        [Fact]
        public void Add_GivenNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _unitOfWorkSeeded.VisitData<AudiogramEntity>().Add(null));
        }

        [Fact]
        public void Add_GivenOneEntity_Succeeds()
        {
            var uow = new UnitOfWork(FakeGeekMdSuiteContextBuilder.EmptyContext);
            uow.Audiograms.Add(new AudiogramEntity());
            uow.Complete();

            var count = uow.VisitData<AudiogramEntity>().All().Count();
            Assert.Equal(1, count);
        }
    }
}