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

        public VisitsRepository(GeekMdSuiteDbContext context) : base (context)
        {
        }
        
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
            var patients =  Context.Patients.Where(p => mrn.HasStringsInCommonWith(p.MedicalRecordNumber.ToString()));
            if (!patients.Any())
                throw new RepositoryElementNotFoundException($"There is no patient with medical record number {mrn}.");
            
            foreach (var patient in patients)
                yield return FindByPatientGuid(patient.Guid);
        }

        public IEnumerable<VisitEntity> FindByName(string name)
        {
             if (string.IsNullOrEmpty(name))
                 throw new ArgumentNullException($"{nameof(name)} cannot be null or empty in {nameof(FindByName)}");
            
            var patients = Context.Patients.Where(p => name.HasStringsInCommonWith(p.Name.ToString()));
            
            if (!patients.Any())
                throw new RepositoryElementNotFoundException(name);

            foreach (var patient in patients)
                yield return Context.Visits.First(v => v.PatientGuid == patient.Guid);
        }

        public IEnumerable<VisitEntity> FindByDateOfBirth(DateTime dateOfBirth)
        {
            var patients = Context.Patients.Where(p => p.DateOfBirth.Year == dateOfBirth.Year &&
                                                       p.DateOfBirth.Month == dateOfBirth.Month &&
                                                       p.DateOfBirth.Day == dateOfBirth.Day);
            foreach (var patient in patients)
                yield return Context.Visits.First(v => v.PatientGuid == patient.Guid);
        }
        
        public void Throw() => throw new ArgumentNullException($"From inside this cursed VisitsRepository");
    }
}