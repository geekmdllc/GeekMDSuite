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
    }
}