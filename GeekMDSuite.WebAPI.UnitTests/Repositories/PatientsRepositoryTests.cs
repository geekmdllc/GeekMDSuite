using System;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public class PatientsRepositoryTests
    {
        private readonly IUnitOfWork _unitOfWork = new FakeUnitOfWorkSeeded();

        [Fact]
        public async Task FindByGuid_GivenGuidThatExistsInRepository_ReturnsPatientEntity()
        {
            var found = await _unitOfWork.Patients.FindByGuid(FakeGeekMdSuiteContextBuilder.BruceWaynesGuid);
            Assert.IsType<PatientEntity>(found);
        }

        [Fact]
        public async Task FindByGuid_GivenEmptyGuid_ThrowsRepositoryElementyNotFoundException()
        {
            await Assert.ThrowsAsync<RepositoryEntityNotFoundException>(() => _unitOfWork.Patients.FindByGuid(Guid.Empty));
        }

        [Fact]
        public async Task FilteredSearch_GivenNotFilterParamters_ReturnsAllRepostioryElements()
        {
            var totalCount = (await _unitOfWork.Patients.All()).Count();
            var foundCount = (await _unitOfWork.Patients.FilteredSearch(new PatientDataSearchFilter())).Count();
            Assert.Equal(totalCount, foundCount);
        }

        [Fact]
        public async Task FilteredSearch_GivenBirthDay_ReturnsElementsWithThatBirthDay()
        {
            var actual = (await _unitOfWork.Patients.All()).Where(p => p.DateOfBirth.Day == 1);
            var found = await _unitOfWork.Patients.FilteredSearch(new PatientDataSearchFilter {BirthDay = 1});
            Assert.Equal(actual.Count(), found.Count());
        }
        
        [Fact]
        public async Task FilteredSearch_GivenBirthMonth_ReturnsElementsWithThatBirthDay()
        {
            var actual = (await _unitOfWork.Patients.All()).Where(p => p.DateOfBirth.Month == 1);
            var found = await _unitOfWork.Patients.FilteredSearch(new PatientDataSearchFilter {BirthMonth = 1});
            Assert.Equal(actual.Count(), found.Count());
        }
        
        [Fact]
        public async Task FilteredSearch_GivenExactBirthDate_ReturnsElementsWithThatBirthDate()
        {
            var actual = (await _unitOfWork.Patients.All())
                .Where(p => p.DateOfBirth.Year == 1900)
                .Where(p => p.DateOfBirth.Day == 1)
                .Where(p => p.DateOfBirth.Month == 1);

            var filter = new PatientDataSearchFilter
            {
                BirthYear = 1900,
                BirthMonth = 1,
                BirthDay = 1
            };
            
            var found = await _unitOfWork.Patients.FilteredSearch(filter);
            Assert.Equal(actual.Count(), found.Count());
        }
        
        [Fact]
        public async Task FilteredSearch_GivenBirthYear_ReturnsElementsWithThatBirthDay()
        {
            var actual = (await _unitOfWork.Patients.All()).Where(p => p.DateOfBirth.Year == 1900);
            var found = await _unitOfWork.Patients.FilteredSearch(new PatientDataSearchFilter {BirthYear = 1900});
            Assert.Equal(actual.Count(), found.Count());
        }
        
        [Fact]
        public async Task FilteredSearch_GivenBirthYearThatDoesNotExist_ReturnsEmptySet()
        {
            var found = await _unitOfWork.Patients.FilteredSearch(new PatientDataSearchFilter {BirthYear = 1400});
            Assert.Empty(found);
        }

        [Fact]
        public async Task FilteredSearch_GivenNameThatExists_ReturnsElementsWithThatName()
        {
            var actual = (await _unitOfWork.Patients.All())
                .Where(p => p.Name.IsSimilarTo("Bruce"));
            
            var found = await _unitOfWork.Patients.FilteredSearch(new PatientDataSearchFilter {Name = "Bruce"});
    
            Assert.Equal(actual.Count(), found.Count());
        }
        
        [Fact]
        public async Task FilteredSearch_GivenNameThatDoesNotExist_ReturnsEmptySet()
        {
             var found = await _unitOfWork.Patients.FilteredSearch(new PatientDataSearchFilter {Name = "Jar Jar"});
    
            Assert.Empty(found);
        }
        
        [Fact]
        public async Task FilteredSearch_GivenCompleteMedicalRecordNumberThatExists_ReturnsElementsWithThatCompleteMedicalRecordNumber()
        {
            var actual = (await _unitOfWork.Patients.All())
                .Where(p => p.MedicalRecordNumber.Contains(FakeGeekMdSuiteContextBuilder.BruceWaynesMedicalRecordNumber));
            
            var filter = new PatientDataSearchFilter
            {
                MedicalRecordNumber = FakeGeekMdSuiteContextBuilder.BruceWaynesMedicalRecordNumber
            };
            
            var found = await _unitOfWork.Patients.FilteredSearch(filter);
    
            Assert.Equal(actual.Count(), found.Count());
        }
        
        [Fact]
        public async Task FilteredSearch_GivenIncompleteMedicalRecordNumberThatExists_ReturnsElementsWithThatIncompleteMedicalRecordNumber()
        {
            var all = (await _unitOfWork.Patients.All()).ToList();
            var actual = all.Where(p => p.MedicalRecordNumber.Contains("3"));
            
            var filter = new PatientDataSearchFilter
            {
                MedicalRecordNumber = "3"
            };
            
            var found = await _unitOfWork.Patients.FilteredSearch(filter);
    
            Assert.Equal(all.Count(), found.Count());
            Assert.Equal(actual.Count(), all.Count());
        }

        [Fact]
        public async Task FindByVisit_GivenGuidThatExistsInRepository_ReturnsPatientEntity()
        {
            var found = await _unitOfWork.Patients.FindByVisit(FakeGeekMdSuiteContextBuilder.BruceWaynesVisitGuid);
            Assert.IsType<PatientEntity>(found);
        }
        
        [Fact]
        public async Task FindByVisit_GivenGuidThatDoesNotExistInRepository_ThrowsRepositoryElementNotFoundException()
        {
            await Assert.ThrowsAsync<RepositoryEntityNotFoundException>(() =>
                _unitOfWork.Patients.FindByVisit(Guid.NewGuid()));
        }

        [Fact]
        public async Task Update_GivenDeletionOfComorbidity_PersistsChanges()
        {
            var patientBefore = await _unitOfWork.Patients.FindByGuid(FakeGeekMdSuiteContextBuilder.XerMajestyGuid);
            patientBefore.Comorbidities.RemoveAll(c => c == ChronicDisease.Diabetes);
            await _unitOfWork.Complete();

            var patientAfter = await _unitOfWork.Patients.FindById(patientBefore.Id);

            Assert.DoesNotContain(ChronicDisease.Diabetes, patientAfter.Comorbidities);
        }

        [Fact]
        public async Task Update_GivenNewComorbidit_PersistsChanges()
        {
            var patientBefore = (await _unitOfWork.Patients.All()).First();
            patientBefore.Comorbidities.Add(ChronicDisease.Asthma);
            await _unitOfWork.Complete();

            var patientAfter = await _unitOfWork.Patients.FindById(patientBefore.Id);

            Assert.Contains(ChronicDisease.Asthma, patientAfter.Comorbidities);
        }

        [Fact]
        public async Task Update_GivenNewDateOfBirth_PersistsChanges()
        {
            var found =
                (await _unitOfWork.Patients.FilteredSearch(new PatientDataSearchFilter {Name = "bruce"})).First();
            var originalBirthDate = found.DateOfBirth;
            var newBirthDate = new DateTime(1955, 5, 5);
            found.DateOfBirth = newBirthDate;

            await _unitOfWork.Patients.Update(found);
            await _unitOfWork.Complete();

            var foundAgain = await _unitOfWork.Patients.FindById(found.Id);

            Assert.NotEqual(originalBirthDate, foundAgain.DateOfBirth);
            Assert.Equal(newBirthDate, foundAgain.DateOfBirth);
        }

        [Fact]
        public async Task Update_GivenNewGender_PersistsChanges()
        {
            var patientBefore =
                (await _unitOfWork.Patients.FilteredSearch(new PatientDataSearchFilter {MedicalRecordNumber = "12345"}))
                .First();
            var genderBefore = Gender.Build(patientBefore.Gender.Category);
            var updatedPatient = new PatientEntity
            {
                Id = patientBefore.Id,
                Gender = Gender.Build(GenderIdentity.NonBinaryXy)
            };

            await _unitOfWork.Patients.Update(updatedPatient);
            await _unitOfWork.Complete();

            var patientAfter = await _unitOfWork.Patients.FindById(patientBefore.Id);

            Assert.NotEqual(genderBefore.Category, patientAfter.Gender.Category);
            Assert.Equal(updatedPatient.Gender.Category, patientAfter.Gender.Category);
            Assert.Equal(Gender.IsGenotypeXx(updatedPatient.Gender), Gender.IsGenotypeXx(patientAfter.Gender));
        }

        [Fact]
        public async Task Update_GivenNewMedicalRecordNumber_PersistsChanges()
        {
            var patientBefore =
                (await _unitOfWork.Patients.FilteredSearch(new PatientDataSearchFilter {MedicalRecordNumber = "12345"}))
                .First();
            var mrnBefore = patientBefore.MedicalRecordNumber;
            var updatedPatient = new PatientEntity
            {
                Id = patientBefore.Id,
                MedicalRecordNumber = "23456"
            };

            await _unitOfWork.Patients.Update(updatedPatient);
            await _unitOfWork.Complete();

            var patientAfter = await _unitOfWork.Patients.FindById(patientBefore.Id);

            Assert.Equal("23456", patientAfter.MedicalRecordNumber);
            Assert.NotEqual(mrnBefore, "23456");
        }

        [Fact]
        public async Task Update_GivenNewName_PersistsChanges()
        {
            var patientBefore =
                (await _unitOfWork.Patients.FilteredSearch(new PatientDataSearchFilter {MedicalRecordNumber = "12345"}))
                .First();
            var nameBefore = Name.Build(patientBefore.Name.First, patientBefore.Name.Last, patientBefore.Name.Middle);
            var newName = Name.Build(nameBefore.First, nameBefore.Last, "Robert");
            var updatedPatient = new PatientEntity
            {
                Id = patientBefore.Id,
                Name = newName
            };

            await _unitOfWork.Patients.Update(updatedPatient);
            await _unitOfWork.Complete();

            var patientAfter = await _unitOfWork.Patients.FindById(patientBefore.Id);

            Assert.Equal(newName.First, patientAfter.Name.First);
            Assert.Equal(newName.Middle, patientAfter.Name.Middle);
            Assert.Equal(newName.Last, patientAfter.Name.Last);
            Assert.NotEqual(nameBefore.Middle, patientAfter.Name.Middle);
        }

        [Fact]
        public async Task Update_GivenNewRace_PersistsChanges()
        {
            var patientBefore =
                (await _unitOfWork.Patients.FilteredSearch(new PatientDataSearchFilter {MedicalRecordNumber = "12345"}))
                .First();
            var raceBefore = patientBefore.Race;
            const Race newRace = Race.Asian;
            var updatedPatient = new PatientEntity
            {
                Id = patientBefore.Id,
                Race = newRace
            };

            await _unitOfWork.Patients.Update(updatedPatient);
            await _unitOfWork.Complete();

            var patientAfter = await _unitOfWork.Patients.FindById(patientBefore.Id);

            Assert.Equal(newRace, patientAfter.Race);
            Assert.NotEqual(raceBefore, patientAfter.Race);
        }
    }
}