using System;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public class VisitsRepositoryTests
    {

        public VisitsRepositoryTests()
        {
            _emptyRepository= _emptyUnitOfWork.Visits;
            _repository = _unitOfWork.Visits;
        }
        private readonly IUnitOfWork _emptyUnitOfWork = new FakeUnitOfWorkEmpty();
        private  readonly IUnitOfWork _unitOfWork = new FakeUnitOfWorkSeeded();
        private readonly IVisitsRepository _emptyRepository;
        private readonly IVisitsRepository _repository;
        
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
            Assert.IsType<VisitEntity>(visit);
        }

        [Fact]
        public void FindByMedicalRecordNumber_GivenEmptyString_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _repository.FindByMedicalRecordNumber(string.Empty));
        }

        [Fact]
        public void FindByMedicalRecordNumber_GivenRandomString_ThrowsRepositoryElementNotFoundException()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() =>
                _repository.FindByMedicalRecordNumber(Guid.NewGuid().ToString()));
        }

        [Fact]
        public void FindByMedicalRecordNumber_GivenMedicalRecordNumberThatExists_ReturnsCorrectIEnumerable()
        {
            var found = _repository.FindByMedicalRecordNumber(FakeGeekMdSuiteContextBuilder.BruceWaynesMedicalRecordNumber);
            Assert.True(found.Any(v => v.PatientGuid == FakeGeekMdSuiteContextBuilder.BruceWaynesGuid));
        }

        [Fact]
        public void FindByName_GivenEmptyString_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _repository.FindByName(string.Empty));
        }

        [Fact]
        public void FindByName_GivenNameThatDoesntExistInTheContext_ThrowsRepositoryEntryNotFoundException()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() => _repository.FindByName("Jar Jar Binks"));
        }

        [Fact]
        public void FindByDateOfBirth_GivenPatientAgeGreaterThan150Years_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _repository.FindByDateOfBirth(DateTime.Now.AddYears(-151)));
        }
        
        [Fact]
        public void FindByDateOfBirth_GivenDateNotInRepository_ThrowsRepositoryElementNotFoundException()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() => _repository.FindByDateOfBirth(DateTime.Now));
        }
        
        [Fact]
        public void FindByDateOfBirth_GivenDateInRepository_ReturnsProperIEnumerableOfVisitEntities()
        {
            var list = _repository.FindByDateOfBirth(new DateTime(1900, 1, 1));
            Assert.True(list.Any(v => v.PatientGuid == FakeGeekMdSuiteContextBuilder.BruceWaynesGuid));
        }
    }
}