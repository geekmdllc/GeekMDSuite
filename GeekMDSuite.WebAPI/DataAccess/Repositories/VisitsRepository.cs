using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.Helpers;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class VisitsRepository : Repository<VisitEntity>, IVisitRepository
    {

        public VisitsRepository(GeekMdSuiteDbContext context) : base (context)
        {
        }
        
        public VisitEntity FindByPatientGuid(Guid patientGuid)
        {
            return Context.Visits.First(v => v.PatientGuid == patientGuid);
        }

        public IEnumerable<VisitEntity> FindByMedicalRecordNumber(string mrn)
        {
            var patients =  Context.Patients.Where(p => StringHelpers.HasWordsInCommonWith(mrn, p.MedicalRecordNumber.ToString()));
            foreach (var patient in patients)
                yield return FindByPatientGuid(patient.Guid);
        }

        public IEnumerable<VisitEntity> FindByName(string name)
        {
            var patients = Context.Patients.Where(p => StringHelpers.HasWordsInCommonWith(name, p.Name.ToString()));
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
    }
}