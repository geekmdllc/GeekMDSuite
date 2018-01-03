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
        public void All_ReturnsNonEmptyList()
        {
            var found = _unitOfWorkSeeded.VisitData<AudiogramEntity>().All();
            
            Assert.True(found.Any());
        }

        [Fact]
        public void All_GivenEmptyContext_ReturnsEmptyList()
        {
            var found = _unitOfWorkEmpty.VisitData<AudiogramEntity>().All();
            
            Assert.False(found.Any());
        }

        [Fact]
        public void FindById_ReturnsCorrectEntity()
        {
            var uow = new FakeUnitOfWorkSeeded();
            var firstId = uow.VisitData<AudiogramEntity>().All().First().Id;
            var foundAudiogram = uow.VisitData<AudiogramEntity>().FindById(firstId);
            
            Assert.Equal(firstId, foundAudiogram.Id);
            Assert.IsType<AudiogramEntity>(foundAudiogram);
            Assert.Equal(90, foundAudiogram.Left.F500.Value);
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
            var uow = new UnitOfWork(FakeGeekMdSuiteContextBuilder.EmptyContext);
            uow.Audiograms.Add(new AudiogramEntity());
            uow.Complete();
            
            uow.VisitData<AudiogramEntity>().Delete(uow.Audiograms.All().First().Id);
            uow.Complete();

            var count = uow.VisitData<AudiogramEntity>().All().Count();
            Assert.Equal(0, count);
        }

        private readonly IUnitOfWork _unitOfWorkSeeded = new FakeUnitOfWorkSeeded();
        private readonly IUnitOfWork _unitOfWorkEmpty = new FakeUnitOfWorkEmpty();
    }
    
}