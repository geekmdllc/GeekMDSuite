using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Exceptions;
using GeekMDSuite.WebAPI.Helpers;
using GeekMDSuite.WebAPI.Models;
using GeekMDSuite.WebAPI.Persistence;

namespace GeekMDSuite.WebAPI.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        public PatientRepository(GeekMdSuiteDbContext context)
        {
            _context = context;
        }


        public IEnumerable<PatientEntity> All() => _context.Patients;

        public PatientEntity FindById(int id)
        {
            try
            {
                return _context.Patients.First(p => p.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public IEnumerable<PatientEntity> FindByName(string query) => 
            _context.Patients.Where(p => StringHelpers.StringContainsQuery(query, p.Name.ToString()));

        public IEnumerable<PatientEntity> FindByMedicalRecordNumber(string query) => 
            _context.Patients.Where(p => StringHelpers.StringContainsQuery(query, p.MedicalRecordNumber));

        public void Add(PatientEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Patients.Add(entity);
        }

        public void Delete(int id)
        {
            var patient = FindById(id);
            if (patient == null) throw new RepositoryElementNotFoundException(nameof(patient));
            _context.Patients.Remove(patient);
            
        }

        public void Update(PatientEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            
            var entityToUpdate = FindById(entity.Id);
            entityToUpdate.DateOfBirth = entity.DateOfBirth;
            entityToUpdate.Gender.Category = entity.Gender.Category;
            entityToUpdate.MedicalRecordNumber = entity.MedicalRecordNumber;
            entityToUpdate.Name.First = entity.Name.First;
            entityToUpdate.Name.Middle = entity.Name.Middle;
            entityToUpdate.Name.Last = entity.Name.Last;
            entityToUpdate.Race = entity.Race;
        }

        private readonly GeekMdSuiteDbContext _context;
    }
}