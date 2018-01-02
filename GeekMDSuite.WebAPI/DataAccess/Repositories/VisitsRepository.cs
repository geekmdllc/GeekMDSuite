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
    public class VisitsRepository : RepositoryAssociatedWithVisit<VisitEntity>, IVisitsRepository
    {
        public VisitsRepository(GeekMdSuiteDbContext context) : base (context) { }
       
        public IEnumerable<VisitEntity> FindByMedicalRecordNumber(string mrn)
        {
            if (string.IsNullOrEmpty(mrn)) 
                throw new ArgumentNullException(mrn);
            
            var patientGuids = Context.Patients.Where(p => p.MedicalRecordNumber.IsEqualTo(mrn)) .Select(p => p.Guid);
            
            if (!patientGuids.Any())
                throw new RepositoryElementNotFoundException(mrn);

            var visits = new List<VisitEntity>();
            foreach (var guid in patientGuids)
                visits.AddRange(FindByPatientGuid(guid));

            if (!visits.Any())
                throw new RepositoryElementNotFoundException(mrn);

            return visits;
        }

        public IEnumerable<VisitEntity> FindByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(name);

            var patientGuids = Context.Patients.Where(p => p.Name.IsSimilarTo(name)) .Select(p => p.Guid);
            
            if (!patientGuids.Any())
                throw new RepositoryElementNotFoundException(name);

            var visits = new List<VisitEntity>();
            foreach (var guid in patientGuids)
                visits.AddRange(FindByPatientGuid(guid));

            if (!visits.Any())
                throw new RepositoryElementNotFoundException(name);

            return visits;
        }

        public IEnumerable<VisitEntity> FindByDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth.IsInvalidAge())
                throw new ArgumentOutOfRangeException(dateOfBirth.ToShortDateString());

            var dobString = dateOfBirth.ToShortDateString();            
            var patientGuids = Context.Patients.Where(p => p.DateOfBirth.ToShortDateString().HasStringsInCommonWith(dobString)).Select(p => p.Guid);
            
            if (!patientGuids.Any())
                throw new RepositoryElementNotFoundException(dobString);

            var visits = new List<VisitEntity>();
            foreach (var guid in patientGuids)
                visits.AddRange(FindByPatientGuid(guid));

            if (!visits.Any())
                throw new RepositoryElementNotFoundException(dobString);

            return visits;
        }
    }
}