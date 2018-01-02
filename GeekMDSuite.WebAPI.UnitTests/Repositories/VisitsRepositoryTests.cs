using System;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public class VisitsRepositoryTests
    {

        [Fact]
        public void FindByPatientGuid_GivenEmptyGuid_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _repo.FindByPatientGuid(Guid.Empty));
        }

        [Fact]
        public void FindByPatientGuid_GivenRandomGuid_ThrowsRepositoryElementNotFoundExcpetion()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() => _repo.FindByPatientGuid(Guid.NewGuid()));
        }

        [Fact]
        public void FindByPatientGuid_GivenGuidOfExistingVisit_ReturnsVisit()
        {
            var visit = _repo.FindByPatientGuid(FakeGeekMdSuiteContextBuilder.BruceWaynesGuid);
            Assert.IsType<VisitEntity>(visit.First());
        }

        [Fact]
        public void FindByMedicalRecordNumber_GivenEmptyString_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _repo.FindByMedicalRecordNumber(string.Empty));
        }

        [Fact]
        public void FindByMedicalRecordNumber_GivenRandomString_ThrowsRepositoryElementNotFoundException()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() =>
                _repo.FindByMedicalRecordNumber(Guid.NewGuid().ToString()));
        }

        [Fact]
        public void FindByMedicalRecordNumber_GivenMedicalRecordNumberThatExists_ReturnsCorrectIEnumerable()
        {
            var found = _repo.FindByMedicalRecordNumber(FakeGeekMdSuiteContextBuilder.BruceWaynesMedicalRecordNumber);
            Assert.True(found.Any(v => v.PatientGuid == FakeGeekMdSuiteContextBuilder.BruceWaynesGuid));
        }

        [Fact]
        public void FindByName_GivenEmptyString_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _repo.FindByName(string.Empty));
        }

        [Fact]
        public void FindByName_GivenNameThatDoesntExistInTheContext_ThrowsRepositoryEntryNotFoundException()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() => _repo.FindByName("Jar Jar Binks"));
        }

        [Fact]
        public void FindByName_GivenNameThatDoesExistInTheContext_ReturnsCorrectIEnumerable()
        {
            var found = _repo.FindByName("Bruce Wayne");
            Assert.True(found.Any(v => v.PatientGuid == FakeGeekMdSuiteContextBuilder.BruceWaynesGuid));
        }
        
        [Fact]
        public void FindByDateOfBirth_GivenDateInRepository_ReturnsProperIEnumerableOfVisitEntities()
        {
            var list = _repo.FindByDateOfBirth(new DateTime(1900, 1, 1));
            Assert.True(list.Any(v => v.PatientGuid == FakeGeekMdSuiteContextBuilder.BruceWaynesGuid));
        }
        [Fact]
        public void FindByDateOfBirth_GivenPatientAgeGreaterThan150Years_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _repo.FindByDateOfBirth(DateTime.Now.AddYears(-151)));
        }
        
        [Fact]
        public void FindByDateOfBirth_GivenDateNotInRepository_ThrowsRepositoryElementNotFoundException()
        {
            Assert.Throws<RepositoryElementNotFoundException>(() => _repo.FindByDateOfBirth(DateTime.Now));
        }
        private readonly IVisitsRepository _repo = new VisitsRepository(FakeGeekMdSuiteContextBuilder.Context);

    }
}