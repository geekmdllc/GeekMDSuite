using System;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Repositories;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests
{
    public class RepositoryTests
    {
        [Fact]
        public void All_ReturnsNonEmptyList()
        {
            var found = _unitOfWork.Audiograms.All();
            
            Assert.True(found.Any());
        }

        [Fact]
        public void FindById_ReturnsCorrectEntity()
        {
            var foundAudiogram = _unitOfWork.Audiograms.FindById(1);
            
            Assert.Equal(1, foundAudiogram.Id);
            Assert.IsType<AudiogramEntity>(foundAudiogram);
            Assert.Equal(90, foundAudiogram.Left.F500.Value);
        }

        [Fact]
        public void FindById_GivenIndexOutOfRange_ReturnsNull()
        {
            var foundAudiogram = _unitOfWork.Audiograms.FindById(int.MaxValue);
            
            Assert.Equal(null, foundAudiogram);
        }

        [Fact]
        public void Add_GivenNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _unitOfWork.Audiograms.Add(null));
        }

        [Fact]
        public void Add_GivenOneEntity_Succeeds()
        {
            _unitOfWork.Audiograms.Add(new AudiogramEntity());
            _unitOfWork.Complete();
            Assert.Equal(3, _unitOfWork.Audiograms.All().Count());
        }

        [Fact]
        public void Delete_GivenIndexOutOfRange_ThrowsRepositoryElementNotFoundException()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() => _unitOfWork.Audiograms.Delete(int.MaxValue));
        }
        
        [Fact]
        public void Delete_GivenOneId_Succeeds()
        {
            var beforeIndex = _unitOfWork.Audiograms.All().Count();
            _unitOfWork.Audiograms.Delete(beforeIndex);
            _unitOfWork.Complete();

            var afterIndex = _unitOfWork.Audiograms.All().Count();
            Assert.Equal(beforeIndex - 1, afterIndex);
        }

        private readonly IUnitOfWork _unitOfWork = new UnitOfWork(FakeGeekMdSuiteContextBuilder.Context);
    }
    
}