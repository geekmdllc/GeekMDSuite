using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Helpers;
using GeekMDSuite.WebAPI.Models;
using GeekMDSuite.WebAPI.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        public PatientRepository(GeekMdSuiteDbContext context)
        {
            _context = context;
        }

        public PatientEntity FindById(int id)
        {
            try
            {
                return _context.Patients.First(p => p.Id == id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<PatientEntity> All() => _context.Patients;

        public IEnumerable<PatientEntity> FindByName(string query) => 
            _context.Patients.Where(p => StringHelpers.StringContainsQuery(query, p.Name.ToString()));

        public IEnumerable<PatientEntity> FindByMedicalRecordNumber(string query) => 
            _context.Patients.Where(p => StringHelpers.StringContainsQuery(query, p.MedicalRecordNumber));

        public void Add(PatientEntity patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        private readonly GeekMdSuiteDbContext _context;
    }
}