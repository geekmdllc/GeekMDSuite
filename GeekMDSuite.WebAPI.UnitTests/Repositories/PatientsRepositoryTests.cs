﻿using System;
using System.Linq;
using GeekMDSuite.Core;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess.Fake;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Xunit;

namespace GeekMDSuite.WebAPI.UnitTests.Repositories
{
    public class PatientsRepositoryTests
    {
        [Theory]
        [InlineData("bru")]
        [InlineData("bruce")]
        [InlineData("wayne")]
        [InlineData("bruce wayne")]
        [InlineData("xer")]
        [InlineData("majesty")]
        [InlineData("xer majesty")]
        public void FindByName_GivenNames_ReturnsNonEmptyListIfPatientsNamesExistInDatabase(string name)
        {
            var found = _unitOfWork.Patients.FindByName(name);
            
            Assert.True(found.Any());
        }
        
        [Theory]
        [InlineData("santa clause")]
        [InlineData("easter bunny")]
        public void FindByName_GivenInvalidNames_ThrowsRepositoryElementNotfoundException(string name, bool expected = true)
        {
            Assert.Throws<RepositoryElementNotFoundException>(() => _unitOfWork.Patients.FindByName(name));
        }

        [Theory]
        [InlineData("12345")]
        [InlineData("54321")]
        public void FindByMedicalRecordNumber_GivenCorrectMedicalRecordNumber_ReturnsPatientEntity(string mrn, bool expected = true)
        {
            var found = _unitOfWork.Patients.FindByMedicalRecordNumber(mrn);
            
            Assert.Equal(expected, found.Any());
        }
        
        [Theory]
        [InlineData("99999", false)]
        [InlineData("00000", false)]
        public void FindByMedicalRecordNumber_GivenNumbersThatDoNotExistInRepository_ThrowsRepositoryElementNotFoundException(string mrn, bool expected = true)
        {
            Assert.Throws(typeof(RepositoryElementNotFoundException),
                () => _unitOfWork.Patients.FindByMedicalRecordNumber(mrn));
        }
        
        [Theory]
        [InlineData(1900, 1, 1)]
        [InlineData(1990, 2, 2)]
        public void FindByDateOfBirth_GivenValidAge_ReturnsPatientEntity(int year, int month, int day)
        {
            var found = _unitOfWork.Patients.FindByDateOfBirth(new DateTime(year, month, day));
            
            Assert.True(found.Any());
        }
        
        [Fact]
        public void FindByDateOfBirth_GivenAgeGreaterThan150_ThrowsArgumentOutOfRangeException()
        {

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _unitOfWork.Patients.FindByDateOfBirth(DateTime.Now.AddYears(-151)));
        }
        
        [Fact]
        public void FindByDateOfBirth_GivenAgeZeroOrYournger_ThrowsArgumentOutOfRangeException()
        {

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                _unitOfWork.Patients.FindByDateOfBirth(DateTime.Now.AddYears(1)));
        }

        [Fact]
        public void Update_GivenNewDateOfBirth_PersistsChanges()
        {
            var found = _unitOfWork.Patients.FindByName("bruce").First();
            var originalBirthDate = found.DateOfBirth;
            var newBirthDate = new DateTime(1955, 5, 5);
            found.DateOfBirth = newBirthDate;
            
            _unitOfWork.Patients.Update(found);
            _unitOfWork.Complete();
            
            var foundAgain = _unitOfWork.Patients.FindById(found.Id);
            
            Assert.NotEqual(originalBirthDate, foundAgain.DateOfBirth);
            Assert.Equal(newBirthDate, foundAgain.DateOfBirth);
        }
        
        [Fact]
        public void Update_GivenNewGender_PersistsChanges()
        {
            var patientBefore = _unitOfWork.Patients.FindByMedicalRecordNumber("12345").First();
            var genderBefore = Gender.Build(patientBefore.Gender.Category);
            var updatedPatient = new PatientEntity()
            {
                Id = patientBefore.Id,
                Gender = Gender.Build(GenderIdentity.NonBinaryXy)
            };
             
            _unitOfWork.Patients.Update(updatedPatient);
            _unitOfWork.Complete();

            var patientAfter = _unitOfWork.Patients.FindById(patientBefore.Id);
            
            Assert.NotEqual(genderBefore.Category, patientAfter.Gender.Category);
            Assert.Equal(updatedPatient.Gender.Category, patientAfter.Gender.Category);
            Assert.Equal(Gender.IsGenotypeXx(updatedPatient.Gender), Gender.IsGenotypeXx(patientAfter.Gender));
        }
        
        [Fact]
        public void Update_GivenNewMedicalRecordNumber_PersistsChanges()
        {
            var patientBefore = _unitOfWork.Patients.FindByMedicalRecordNumber("12345").First();
            var mrnBefore = patientBefore.MedicalRecordNumber;
            var updatedPatient = new PatientEntity()
            {
                Id = patientBefore.Id,
                MedicalRecordNumber = "23456"
            };
             
            _unitOfWork.Patients.Update(updatedPatient);
            _unitOfWork.Complete();

            var patientAfter = _unitOfWork.Patients.FindById(patientBefore.Id);
            
            Assert.Equal("23456", patientAfter.MedicalRecordNumber);
            Assert.NotEqual(mrnBefore, "23456");
        }
        
        [Fact]
        public void Update_GivenNewName_PersistsChanges()
        {
            var patientBefore = _unitOfWork.Patients.FindByMedicalRecordNumber("12345").First();
            var nameBefore = Name.Build(patientBefore.Name.First, patientBefore.Name.Last, patientBefore.Name.Middle);
            var newName = Name.Build(nameBefore.First, nameBefore.Last, "Robert");
            var updatedPatient = new PatientEntity()
            {
                Id = patientBefore.Id,
                Name =  newName
            };
             
            _unitOfWork.Patients.Update(updatedPatient);
            _unitOfWork.Complete();

            var patientAfter = _unitOfWork.Patients.FindById(patientBefore.Id);
            
            Assert.Equal(newName.First, patientAfter.Name.First);
            Assert.Equal(newName.Middle, patientAfter.Name.Middle);
            Assert.Equal(newName.Last, patientAfter.Name.Last);
            Assert.NotEqual(nameBefore.Middle, patientAfter.Name.Middle);
        }
        
        [Fact]
        public void Update_GivenNewRace_PersistsChanges()
        {
            var patientBefore = _unitOfWork.Patients.FindByMedicalRecordNumber("12345").First();
            var raceBefore = patientBefore.Race;
            var newRace = Race.Asian;
            var updatedPatient = new PatientEntity()
            {
                Id = patientBefore.Id,
                Race = newRace
            };
             
            _unitOfWork.Patients.Update(updatedPatient);
            _unitOfWork.Complete();

            var patientAfter = _unitOfWork.Patients.FindById(patientBefore.Id);
            
            Assert.Equal(newRace, patientAfter.Race);
            Assert.NotEqual(raceBefore, patientAfter.Race);
        }

        private readonly IUnitOfWork _unitOfWork = new FakeUnitOfWorkSeeded();
    }
}