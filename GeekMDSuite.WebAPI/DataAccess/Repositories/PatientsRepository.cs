using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Core.Helpers;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Repositories;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
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