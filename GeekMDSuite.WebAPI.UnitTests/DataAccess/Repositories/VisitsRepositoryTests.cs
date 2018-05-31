using System;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Presentation;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.DataAccess.Repositories
{
    public class VisitsRepositoryTests
    {
        private readonly IUnitOfWork _unitOfWork = new FakeUnitOfWorkSeeded();

        [Fact]
        public async Task FilterdSearch_GivenExactVisitDateThatHasOccured_ReturnsListWithOneVisit()
        {
            var filter = new VisitDataSearchFilter
            {
                VisitMonth = 1,
                VisitDay = 1,
                VisitYear = 2016
            };
            var found = (await _unitOfWork.Visits.FilteredSearch(filter)).ToList();
            Assert.NotEmpty(found);
            Assert.Equal(1, found.Count());
        }

        [Fact]
        public async Task FilterdSearch_GivenMedicalRecordThatDoesNotExist_ReturnsEmptySet()
        {
            var found = await _unitOfWork.Visits.FilteredSearch(
                new VisitDataSearchFilter {MedicalRecordNumber = Guid.NewGuid().ToString()});

            Assert.Empty(found);
        }

        [Fact]
        public async Task FilterdSearch_GivenPartialMedicalRecordThatExists_RetursListOfVisits()
        {
            var expected = await _unitOfWork.Visits.All();
            var found = await _unitOfWork.Visits.FilteredSearch(new VisitDataSearchFilter {MedicalRecordNumber = "3"});

            Assert.Equal(expected.Count(), found.Count());
        }

        [Fact]
        public async Task FilterdSearch_GivenVisitDayThatHasOccured_ReturnsListOfVisits()
        {
            var found = await _unitOfWork.Visits.FilteredSearch(new VisitDataSearchFilter {VisitDay = 1});
            Assert.NotEmpty(found);
        }

        [Fact]
        public async Task FilterdSearch_GivenVisitMonthThatHasOccured_ReturnsListOfVisits()
        {
            var found = await _unitOfWork.Visits.FilteredSearch(new VisitDataSearchFilter {VisitMonth = 1});
            Assert.NotEmpty(found);
        }

        [Fact]
        public async Task FilterdSearch_GivenVisitYearThatHasOccured_ReturnsListOfVisits()
        {
            var found = await _unitOfWork.Visits.FilteredSearch(new VisitDataSearchFilter {VisitYear = 2016});
            Assert.NotEmpty(found);
        }

        [Fact]
        public async Task FilteredSearch_GivenGuidOfPatientThatExists_ReturnsListOfWVisits()
        {
            var filter = new VisitDataSearchFilter
            {
                PatientGuid = FakeGeekMdSuiteContextBuilder.BruceWaynesGuid
            };
            var found = await _unitOfWork.Visits.FilteredSearch(filter);

            Assert.NotEmpty(found);
        }

        [Fact]
        public async Task FilteredSearch_GivenMedicalRecordThatExists_ReturnsListOfVisits()
        {
            var found = await _unitOfWork.Visits.FilteredSearch(new VisitDataSearchFilter
            {
                MedicalRecordNumber = FakeGeekMdSuiteContextBuilder.BruceWaynesMedicalRecordNumber
            });

            Assert.NotEmpty(found);
        }

        [Fact]
        public async Task FilteredSearch_GivenNameThatDoesNotExist_ReturnsEmptySet()
        {
            var found = await _unitOfWork.Visits.FilteredSearch(new VisitDataSearchFilter {Name = "Jar jar"});
            Assert.Empty(found);
        }

        [Fact]
        public async Task FilteredSearch_GivenNameThatExists_ReturnsListOfVisits()
        {
            var found = await _unitOfWork.Visits.FilteredSearch(new VisitDataSearchFilter {Name = "Bruce"});
            Assert.NotEmpty(found);
        }

        [Fact]
        public async Task FindByGuid_GivenEmptyGuid_ReturnsRepositoryElementNotFound()
        {
            await Assert.ThrowsAsync<RepositoryEntityNotFoundException>(() =>
                _unitOfWork.Visits.FindByGuid(Guid.NewGuid()));
        }

        [Fact]
        public async Task FindByGuid_GivenGuidOfVisitThatExists_ReturnsVisit()
        {
            var found = await _unitOfWork.Visits.FindByGuid(FakeGeekMdSuiteContextBuilder.BruceWaynesVisitGuid);
            Assert.IsType<VisitEntity>(found);
        }

        [Fact]
        public async Task FindByPatient_GivenPatientGuidThatDoesNotExist_ReturnsEmptySet()
        {
            var found = await _unitOfWork.Visits.FindByPatient(Guid.NewGuid());
            Assert.Empty(found);
        }

        [Fact]
        public async Task FindByPatient_GivenPatientGuidThatExists_ReturnsListOfVisitEntities()
        {
            var found = await _unitOfWork.Visits.FindByPatient(FakeGeekMdSuiteContextBuilder.BruceWaynesGuid);
            Assert.NotEmpty(found);
        }

        [Fact]
        public async Task Update_GivenNewValues_PersistsChanges()
        {
            var trackedVisit = await _unitOfWork.Visits.FindByGuid(FakeGeekMdSuiteContextBuilder.BruceWaynesVisitGuid);
            var updatedVisit = new VisitEntity();
            updatedVisit.MapValues(trackedVisit);
            updatedVisit.Status = VisitStatus.Complete;
            updatedVisit.Date = DateTime.Now;

            trackedVisit.MapValues(updatedVisit);
            await _unitOfWork.Visits.Update(trackedVisit);
            await _unitOfWork.Complete();

            var result = await _unitOfWork.Visits.FindByGuid(FakeGeekMdSuiteContextBuilder.BruceWaynesVisitGuid);
            Assert.Equal(updatedVisit.Date.ToShortDateString(), result.Date.ToShortDateString());
            Assert.Equal(updatedVisit.Status, result.Status);
            _unitOfWork.Dispose();
        }
    }
}