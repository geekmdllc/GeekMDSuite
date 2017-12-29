using System;
using System.Linq;
using GeekMDSuite.WebAPI.Exceptions;
using GeekMDSuite.WebAPI.Models;
using GeekMDSuite.WebAPI.Repositories;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests
{
    public class RepositoryTests
    {
        [Fact]
        public void All_ReturnsCorrectNumberOfEntities()
        {
            var unitOfWork = new UnitOfWork(FakeGeekMdSuiteContextBuilder.Context);
            var found = unitOfWork.Audiograms.All();
            
            Assert.True(found.Any());
        }

        [Fact]
        public void FindById_ReturnsCorrectEntity()
        {
            var unitOfWork = new UnitOfWork(FakeGeekMdSuiteContextBuilder.Context);
            var foundAudiogram = unitOfWork.Audiograms.FindById(1);
            
            Assert.Equal(1, foundAudiogram.Id);
            Assert.IsType<AudiogramEntity>(foundAudiogram);
            Assert.Equal(90, foundAudiogram.Left.F500.Value);
        }

        [Fact]
        public void FindById_GivenIndexOutOfRange_ReturnsNull()
        {
            var unitOfWork = new UnitOfWork(FakeGeekMdSuiteContextBuilder.Context);
            var foundAudiogram = unitOfWork.Audiograms.FindById(9999);
            
            Assert.Equal(null, foundAudiogram);
        }

        [Fact]
        public void Add_GivenNull_ThrowsArgumentNullException()
        {
            var unitOfWork = new UnitOfWork(FakeGeekMdSuiteContextBuilder.Context);
            Assert.Throws<ArgumentNullException>(() => unitOfWork.Audiograms.Add(null));
        }

        [Fact]
        public void Add_GivenOneEntity_Succeeds()
        {
            var unitOfWork = new UnitOfWork(FakeGeekMdSuiteContextBuilder.Context);
            unitOfWork.Audiograms.Add(new AudiogramEntity());
            unitOfWork.Complete();
            Assert.Equal(3, unitOfWork.Audiograms.All().Count());
        }

        [Fact]
        public void Delete_GivenIndexOutOfRange_ThrowsRepositoryElementNotFoundException()
        {
            var unitOfWork = new UnitOfWork(FakeGeekMdSuiteContextBuilder.Context);
            Assert.Throws<RepositoryElementNotFoundException>(() => unitOfWork.Audiograms.Delete(9999));
        }
        
        [Fact]
        public void Delete_GivenOneId_Succeeds()
        {
            var unitOfWork = new UnitOfWork(FakeGeekMdSuiteContextBuilder.Context);
            var beforeIndex = unitOfWork.Audiograms.All().Count();
            unitOfWork.Audiograms.Delete(beforeIndex);
            unitOfWork.Complete();

            var afterIndex = unitOfWork.Audiograms.All().Count();
            Assert.Equal(beforeIndex - 1, afterIndex);
        }

    }
    
}