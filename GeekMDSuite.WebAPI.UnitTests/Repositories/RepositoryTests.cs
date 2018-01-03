using System;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public class RepositoryTests
    {
        [Fact]
        public void All_GivenSeededContext_ReturnsNonEmptyList()
        {
            var found = _unitOfWorkSeeded.VisitData<AudiogramEntity>().All();
            
            Assert.True(found.Any());
        }

        [Fact]
        public void All_GivenEmptyContext_ThrowsRepositoryElementNotFoundException()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() =>
                _unitOfWorkEmpty.VisitData<AudiogramEntity>().All());
        }

        [Fact]
        public void FindById_ReturnsCorrectEntity()
        {
            var firstEntity = _unitOfWorkSeeded.EntityData<AudiogramEntity>().All().First();
            var foundEntity = _unitOfWorkSeeded.EntityData<AudiogramEntity>().FindById(firstEntity.Id);
            Assert.Equal(firstEntity, foundEntity);
        }

        [Fact]
        public void FindById_GivenEmptyContext_ThrowsRepositoryElementNotFoundException()
        {
            var repository = _unitOfWorkEmpty.VisitData<AudiogramEntity>();
            
            Assert.Throws<RepositoryElementNotFoundException>(() => repository.FindById(1));
        }

        [Fact]
        public void FindById_GivenIndexWithoutElement_ThrowsRespositoryNotFoundException()
        {
            var audiograms = _unitOfWorkSeeded.VisitData<AudiogramEntity>();

            Assert.Throws<RepositoryElementNotFoundException>(() => audiograms.FindById(int.MaxValue));
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

        [Fact]
        public void Delete_GivenIndexOutOfRange_ThrowsRepositoryElementNotFoundException()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() => _unitOfWorkSeeded.VisitData<AudiogramEntity>().Delete(int.MaxValue));
        }
        
        [Fact]
        public void Delete_GivenOneId_Succeeds()
        {
            var uow = new UnitOfWork(FakeGeekMdSuiteContextBuilder.Context);
            var countBefore = uow.VisitData<AudiogramEntity>().All().Count();
            uow.VisitData<AudiogramEntity>().Delete(_unitOfWorkSeeded.Audiograms.All().First().Id);
            uow.Complete();

            var countAfter = uow.VisitData<AudiogramEntity>().All().Count();
            Assert.Equal(countBefore - 1, countAfter);
        }

        private readonly IUnitOfWork _unitOfWorkSeeded = new FakeUnitOfWorkSeeded();
        private readonly IUnitOfWork _unitOfWorkEmpty = new FakeUnitOfWorkEmpty();
    }
    
}