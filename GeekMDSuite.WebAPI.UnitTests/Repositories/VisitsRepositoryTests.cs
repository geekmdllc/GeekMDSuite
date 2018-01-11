using System;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public class VisitsRepositoryTests
    {
        private readonly IVisitsRepositoryAsync _repo = new VisitsRepositoryAsync(FakeGeekMdSuiteContextBuilder.Context);

        [Fact]
        public async Task FindByDateOfBirth_GivenDateInRepository_ReturnsProperIEnumerableOfVisitEntities()
        {
            var list = await _repo.FindByDateOfBirth(new DateTime(1900, 1, 1));
            Assert.True(list.Any(v => v.PatientGuid == FakeGeekMdSuiteContextBuilder.BruceWaynesGuid));
        }

        [Fact]
        public async Task FindByDateOfBirth_GivenDateNotInRepository_ThrowsRepositoryElementNotFoundException()
        {
            await Assert.ThrowsAsync<RepositoryElementNotFoundException>(() => _repo.FindByDateOfBirth(DateTime.Now));
        }

        [Fact]
        public async Task FindByDateOfBirth_GivenPatientAgeGreaterThan150Years_ThrowsArgumentOutOfRangeException()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _repo.FindByDateOfBirth(DateTime.Now.AddYears(-151)));
        }

        [Fact]
        public async Task FindByMedicalRecordNumber_GivenEmptyString_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repo.FindByMedicalRecordNumber(string.Empty));
        }

        [Fact]
        public async Task FindByMedicalRecordNumber_GivenMedicalRecordNumberThatExists_ReturnsCorrectIEnumerable()
        {
            var found = await _repo.FindByMedicalRecordNumber(FakeGeekMdSuiteContextBuilder.BruceWaynesMedicalRecordNumber);
            Assert.True(found.Any(v => v.PatientGuid == FakeGeekMdSuiteContextBuilder.BruceWaynesGuid));
        }

        [Fact]
        public async Task FindByMedicalRecordNumber_GivenRandomString_ThrowsRepositoryElementNotFoundException()
        {
            await Assert.ThrowsAsync<RepositoryElementNotFoundException>(() =>
                _repo.FindByMedicalRecordNumber(Guid.NewGuid().ToString()));
        }

        [Fact]
        public async Task FindByName_GivenEmptyString_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repo.FindByName(string.Empty));
        }

        [Fact]
        public async Task FindByName_GivenFirstNameThatDoesExistInTheContext_ReturnsCorrectIEnumerable()
        {
            var found = await _repo.FindByName("Bruce");
            Assert.True(found.Any(v => v.PatientGuid == FakeGeekMdSuiteContextBuilder.BruceWaynesGuid));
        }

        [Fact]
        public async Task FindByName_GivenLastNameThatDoesExistInTheContext_ReturnsCorrectIEnumerable()
        {
            var found = await _repo.FindByName("Wayne");
            Assert.True(found.Any(v => v.PatientGuid == FakeGeekMdSuiteContextBuilder.BruceWaynesGuid));
        }

        [Fact]
        public async Task FindByName_GivenNameThatDoesExistInTheContext_ReturnsCorrectIEnumerable()
        {
            var found = await _repo.FindByName("Bruce Wayne");
            Assert.True(found.Any(v => v.PatientGuid == FakeGeekMdSuiteContextBuilder.BruceWaynesGuid));
        }

        [Fact]
        public async Task FindByName_GivenNameThatDoesntExistInTheContext_ThrowsRepositoryEntryNotFoundException()
        {
            await Assert.ThrowsAsync<RepositoryElementNotFoundException>(() => _repo.FindByName("Jar Jar Binks"));
        }

        [Fact]
        public async Task FindByName_GivenPartialFirstNameThatDoesExistInTheContext_ReturnsCorrectIEnumerable()
        {
            var found = await _repo.FindByName("Br");
            Assert.True(found.Any(v => v.PatientGuid == FakeGeekMdSuiteContextBuilder.BruceWaynesGuid));
        }

        [Fact]
        public async Task FindByName_GivenPartialLastNameThatDoesExistInTheContext_ReturnsCorrectIEnumerable()
        {
            var found = await _repo.FindByName("ayne");
            Assert.True(found.Any(v => v.PatientGuid == FakeGeekMdSuiteContextBuilder.BruceWaynesGuid));
        }

        [Fact]
        public async Task FindByPatientGuid_GivenEmptyGuid_ThrowsArgumentOutOfRangeException()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _repo.FindByPatientGuid(Guid.Empty));
        }

        [Fact]
        public async Task FindByPatientGuid_GivenGuidOfExistingVisit_ReturnsVisit()
        {
            var visit = await _repo.FindByPatientGuid(FakeGeekMdSuiteContextBuilder.BruceWaynesGuid);
            Assert.IsType<VisitEntity>(visit.First());
        }

        [Fact]
        public async Task FindByPatientGuid_GivenRandomGuid_ThrowsRepositoryElementNotFoundExcpetion()
        {
            await Assert.ThrowsAsync<RepositoryElementNotFoundException>(() => _repo.FindByPatientGuid(Guid.NewGuid()));
        }
    }
}