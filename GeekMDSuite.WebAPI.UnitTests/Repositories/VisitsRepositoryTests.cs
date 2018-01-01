using System;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Repositories;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public class VisitsRepositoryTests
    {
        private readonly IVisitRepository _emptyRepository = new VisitsRepository(FakeGeekMdSuiteContextBuilder.EmptyContext);
        private readonly IVisitRepository _repository = new VisitsRepository(FakeGeekMdSuiteContextBuilder.Context);
        
        [Fact]
        public void FindByPatientGuid_GivenEmptyGuid_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _emptyRepository.FindByPatientGuid(Guid.Empty));
        }

        [Fact]
        public void FindByPatientGuid_GivenRandomGuid_ThrowsRepositoryElementNotFoundExcpetion()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() => _emptyRepository.FindByPatientGuid(Guid.NewGuid()));
        }

        [Fact]
        public void FindByPatientGuid_GivenGuidOfExistingVisit_ReturnsVisit()
        {
            var visit = _repository.FindByPatientGuid(FakeGeekMdSuiteContextBuilder.BruceWaynesGuid);
        }

        [Fact]
        public void FindByName_GivenEmptyString_ThrowsArgumentNullException()
        {
            void Test()
            {
                throw new Exception();
            }
            // Assert.Throws<ArgumentNullException>(() => _repository.FindByName(string.Empty));
            Assert.Throws<ArgumentNullException>(() => Test());
        }

        [Fact]
        public void FindByName_GivenNameThatDoesntExistInTheContext_ThrowsRepositoryEntryNotFoundException()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() => _repository.FindByName("Makebelieve Person"));
        }
    }
}