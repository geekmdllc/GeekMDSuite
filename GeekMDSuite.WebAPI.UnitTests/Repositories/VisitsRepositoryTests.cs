using System;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public class VisitsRepositoryTests
    {
        private readonly IUnitOfWork _unitOfWork = new FakeUnitOfWorkSeeded();
        
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
        public async Task FilterdSearch_GivenPartialMedicalRecordThatExists_RetursListOfVisits()
        {
            var expected = await _unitOfWork.Visits.All();
            var found = await _unitOfWork.Visits.FilteredSearch(new VisitDataSearchFilter{ MedicalRecordNumber = "3" });
            
            Assert.Equal(expected.Count(), found.Count());
        }
        
        [Fact]
        public async Task FilterdSearch_GivenMedicalRecordThatDoesNotExist_ReturnsEmptySet()
        {
            var found = await _unitOfWork.Visits.FilteredSearch(new VisitDataSearchFilter{ MedicalRecordNumber = Guid.NewGuid().ToString() });
            
            Assert.Empty(found);
        }
    }
}