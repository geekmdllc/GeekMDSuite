using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Helpers;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class VisitsRepository : Repository<VisitEntity>, IVisitsRepository
    {
        public VisitsRepository(GeekMdSuiteDbContext context) : base (context) { }
        
        public VisitEntity FindByPatientGuid(Guid patientGuid)
        {
            if (patientGuid == Guid.Empty) 
                throw new ArgumentOutOfRangeException($"{nameof(patientGuid)} must not be an empty Guid.");

            try
            {
                return Context.Visits.First(v => v.PatientGuid == patientGuid);
            }
            catch
            {
                throw new RepositoryElementNotFoundException(patientGuid.ToString());
            }
            
        }

        public IEnumerable<VisitEntity> FindByMedicalRecordNumber(string mrn)
        {
            if (string.IsNullOrEmpty(mrn)) 
                throw new ArgumentNullException(mrn);
            
            var patientGuids = Context.Patients.Where(p => p.MedicalRecordNumber.IsEqualTo(mrn))? .Select(p => p.Guid);
            
            if (!patientGuids.Any())
                throw new RepositoryElementNotFoundException(mrn);

            var visits = new List<VisitEntity>();
            foreach (var guid in patientGuids)
                visits.Add(FindByPatientGuid(guid));

            if (!visits.Any())
                throw new RepositoryElementNotFoundException(mrn);

            return visits;
        }

        public IEnumerable<VisitEntity> FindByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(name);

            var patientGuids = Context.Patients.Where(p => p.Name.IsSimilarTo(name))? .Select(p => p.Guid);
            
            if (!patientGuids.Any())
                throw new RepositoryElementNotFoundException(name);

            var visits = new List<VisitEntity>();
            foreach (var guid in patientGuids)
                visits.Add(FindByPatientGuid(guid));

            if (!visits.Any())
                throw new RepositoryElementNotFoundException(name);

            return visits;
        }

        public IEnumerable<VisitEntity> FindByDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth <= DateTime.Now.AddYears(-150))
                throw new ArgumentOutOfRangeException(dateOfBirth.ToShortDateString());
            throw new NotImplementedException();
        }
    }
}