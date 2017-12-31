using System;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Exceptions;
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
            var found = _unitOfWorkSeeded.VisitDataRepository<AudiogramEntity>().All();
            
            Assert.True(found.Any());
        }

        [Fact]
        public void All_GivenEmptyContext_ReturnsEmptyList()
        {
            var found = _unitOfWorkEmpty.VisitDataRepository<AudiogramEntity>().All();
            
            Assert.False(found.Any());
        }

        [Fact]
        public void FindById_ReturnsCorrectEntity()
        {
            var foundAudiogram = _unitOfWorkSeeded.VisitDataRepository<AudiogramEntity>().FindById(1);
            
            Assert.Equal(1, foundAudiogram.Id);
            Assert.IsType<AudiogramEntity>(foundAudiogram);
            Assert.Equal(90, foundAudiogram.Left.F500.Value);
        }

        [Fact]
        public void FindById_GivenEmptyContext_ThrowsRepositoryElementNotFoundException()
        {
            var repository = _unitOfWorkEmpty.VisitDataRepository<AudiogramEntity>();
            
            Assert.Throws<RepositoryElementNotFoundException>(() => repository.FindById(1));
        }

        [Fact]
        public void FindById_GivenIndexWithoutElement_ThrowsRespositoryNotFoundException()
        {
            var audiograms = _unitOfWorkSeeded.VisitDataRepository<AudiogramEntity>();

            Assert.Throws<RepositoryElementNotFoundException>(() => audiograms.FindById(int.MaxValue));
        }

        [Fact]
        public void Add_GivenNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _unitOfWorkSeeded.VisitDataRepository<AudiogramEntity>().Add(null));
        }

        [Fact]
        public void Add_GivenOneEntity_Succeeds()
        {
            _unitOfWorkSeeded.VisitDataRepository<AudiogramEntity>().Add(new AudiogramEntity());
            _unitOfWorkSeeded.Complete();
            Assert.Equal(3, _unitOfWorkSeeded.VisitDataRepository<AudiogramEntity>().All().Count());
        }

        [Fact]
        public void Delete_GivenIndexOutOfRange_ThrowsRepositoryElementNotFoundException()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() => _unitOfWorkSeeded.VisitDataRepository<AudiogramEntity>().Delete(int.MaxValue));
        }
        
        [Fact]
        public void Delete_GivenOneId_Succeeds()
        {
            var beforeIndex = _unitOfWorkSeeded.VisitDataRepository<AudiogramEntity>().All().Count();
            _unitOfWorkSeeded.VisitDataRepository<AudiogramEntity>().Delete(beforeIndex);
            _unitOfWorkSeeded.Complete();

            var afterIndex = _unitOfWorkSeeded.VisitDataRepository<AudiogramEntity>().All().Count();
            Assert.Equal(beforeIndex - 1, afterIndex);
        }

        private readonly IUnitOfWork _unitOfWorkSeeded = new FakeUnitOfWorkSeeded();
        private readonly IUnitOfWork _unitOfWorkEmpty = new FakeUnitOfWorkEmpty();
    }
    
}