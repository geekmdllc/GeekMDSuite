using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Helpers;
using GeekMDSuite.WebAPI.Models;
using GeekMDSuite.WebAPI.Persistence;

namespace GeekMDSuite.WebAPI.Repositories
{
    public class PatientsRepository : Repository<PatientEntity>, IPatientsRepository
    {
        public PatientsRepository(GeekMdSuiteDbContext context) : base (context)
        {
        }
        
        public IEnumerable<PatientEntity> FindByName(string query) => 
            Context.Patients.Where(p => StringHelpers.StringContainsQuery(query, p.Name.ToString()));

        public IEnumerable<PatientEntity> FindByMedicalRecordNumber(string query) => 
            Context.Patients.Where(p => StringHelpers.StringContainsQuery(query, p.MedicalRecordNumber));

        public override void Update(PatientEntity entity)
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
    }
}