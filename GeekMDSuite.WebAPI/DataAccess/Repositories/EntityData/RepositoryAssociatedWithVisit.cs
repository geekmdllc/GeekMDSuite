using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Utilities.Extensions;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class RepositoryAssociatedWithVisit<T> : Repository<T>, IRepositoryAssociatedWithVisit<T>
        where T : class, IVisitData<T>
    {
        public RepositoryAssociatedWithVisit(GeekMdSuiteDbContext context) : base(context)
        {
        }

        public IEnumerable<T> FindByVisit(Guid visitGuid)
        {
            if (visitGuid == Guid.Empty)
                throw new ArgumentOutOfRangeException($"{nameof(visitGuid)} must not be an empty Guid.");

            var result = Context.Set<T>().Where(set => set.VisitId == visitGuid);

            if (!result.Any())
                throw new RepositoryElementNotFoundException(visitGuid.ToString());

            return result;
        }

        public IEnumerable<T> FindByPatientGuid(Guid patientGuid)
        {
            var patient = GetPatient(patientGuid);

            var patientVisits = GetVisitsAssociatedWithPatient(patient);

            if (typeof(T) == typeof(VisitEntity))
                return patientVisits as IEnumerable<T>;

            var entities = GetEntitiesAssociatedWithVisit(patientVisits, patientGuid);

            return entities;
        }

        public IEnumerable<T> FindByMedicalRecordNumber(string mrn)
        {
            if (string.IsNullOrEmpty(mrn))
                throw new ArgumentNullException(mrn);

            var patientGuids = Context.Patients.Where(patient => patient.MedicalRecordNumber.IsEqualTo(mrn))
                .Select(p => p.Guid);

            if (!patientGuids.Any())
                throw new RepositoryElementNotFoundException(mrn);

            var entities = new List<T>();
            foreach (var guid in patientGuids)
                entities.AddRange(FindByPatientGuid(guid));

            if (!entities.Any())
                throw new RepositoryElementNotFoundException(mrn);

            return entities;
        }

        public IEnumerable<T> FindByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(name);

            var patientGuids = Context.Patients.Where(patient => patient.Name.IsSimilarTo(name)).Select(p => p.Guid);

            if (!patientGuids.Any())
                throw new RepositoryElementNotFoundException(name);

            var entities = new List<T>();
            foreach (var guid in patientGuids)
                entities.AddRange(FindByPatientGuid(guid));

            if (!entities.Any())
                throw new RepositoryElementNotFoundException(name);

            return entities;
        }

        public IEnumerable<T> FindByDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth.IsOutOfRange())
                throw new ArgumentOutOfRangeException(dateOfBirth.ToShortDateString());

            var dobString = dateOfBirth.ToShortDateString();
            var patientGuids = Context.Patients
                .Where(patient => patient.DateOfBirth.ToShortDateString().HasStringsInCommonWith(dobString))
                .Select(p => p.Guid);

            if (!patientGuids.Any())
                throw new RepositoryElementNotFoundException(dobString);

            var entities = new List<T>();
            foreach (var guid in patientGuids)
                entities.AddRange(FindByPatientGuid(guid));

            if (!entities.Any())
                throw new RepositoryElementNotFoundException(dobString);

            return entities;
        }

        private PatientEntity GetPatient(Guid patientGuid)
        {
            if (patientGuid == Guid.Empty)
                throw new ArgumentOutOfRangeException($"{nameof(patientGuid)} must not be an empty Guid.");

            PatientEntity patient;
            try
            {
                patient = Context.Patients.First(p => p.Guid == patientGuid);
            }
            catch
            {
                throw new RepositoryElementNotFoundException(patientGuid.ToString());
            }

            return patient;
        }

        private List<T> GetEntitiesAssociatedWithVisit(IQueryable<VisitEntity> patientVisits, Guid patientGuid)
        {
            var entities = new List<T>();
            foreach (var visit in patientVisits)
                entities.AddRange(FindByVisit(visit.VisitId));

            if (!entities.Any())
                throw new RepositoryElementNotFoundException(patientGuid.ToString());

            return entities;
        }

        private IQueryable<VisitEntity> GetVisitsAssociatedWithPatient(PatientEntity patient)
        {
            var patientVisits = Context.Visits.Where(v => v.PatientGuid == patient.Guid);

            if (!patientVisits.Any())
                throw new RepositoryElementNotFoundException(patient.Guid.ToString());
            return patientVisits;
        }
    }
}