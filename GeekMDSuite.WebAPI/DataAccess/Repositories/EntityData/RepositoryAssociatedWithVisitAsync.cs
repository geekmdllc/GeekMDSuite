using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.Utilities.Extensions;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class RepositoryAssociatedWithVisitAsync<T> : RepositoryAsync<T>, IRepositoryAssociatedWithVisitAsync<T>
        where T : class, IVisitData<T>
    {
        public RepositoryAssociatedWithVisitAsync(GeekMdSuiteDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<T>> FindByVisit(Guid visitGuid)
        {
            if (visitGuid == Guid.Empty)
                throw new ArgumentOutOfRangeException($"{nameof(visitGuid)} must not be an empty Guid.");

            var result = await Context.Set<T>().Where(set => set.VisitId == visitGuid).ToListAsync();

            if (!result.Any())
                throw new RepositoryElementNotFoundException(visitGuid.ToString());

            return result;
        }

        public async Task<IEnumerable<T>> FindByPatientGuid(Guid patientGuid)
        {
            var patient = await GetPatient(patientGuid);

            var patientVisits = await GetVisitsAssociatedWithPatient(patient);

            if (typeof(T) == typeof(VisitEntity))
                return patientVisits as IEnumerable<T>;

            var entities = await GetEntitiesAssociatedWithVisit(patientVisits, patientGuid);

            return entities;
        }

        public async Task<IEnumerable<T>> FindByMedicalRecordNumber(string mrn)
        {
            if (string.IsNullOrEmpty(mrn))
                throw new ArgumentNullException(mrn);

            var patientGuids = await Context
                .Patients
                .Where(patient => patient.MedicalRecordNumber.IsEqualTo(mrn))
                .Select(p => p.Guid)
                .ToListAsync();

            if (!patientGuids.Any())
                throw new RepositoryElementNotFoundException(mrn);

            var entities = new List<T>();
            foreach (var guid in patientGuids)
                entities.AddRange(await FindByPatientGuid(guid));

            if (!entities.Any())
                throw new RepositoryElementNotFoundException(mrn);

            return entities;
        }

        public async Task<IEnumerable<T>> FindByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(name);

            var patientGuids = await Context
                .Patients
                .Where(patient => patient.Name.IsSimilarTo(name))
                .Select(p => p.Guid)
                .ToListAsync();

            if (!patientGuids.Any())
                throw new RepositoryElementNotFoundException(name);

            var entities = new List<T>();
            foreach (var guid in patientGuids)
                entities.AddRange(await FindByPatientGuid(guid));

            if (!entities.Any())
                throw new RepositoryElementNotFoundException(name);

            return entities;
        }

        public async Task<IEnumerable<T>> FindByDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth.IsOutOfRange())
                throw new ArgumentOutOfRangeException(dateOfBirth.ToShortDateString());

            var dobString = dateOfBirth.ToShortDateString();
            var patientGuids = await Context.Patients
                .Where(patient => patient.DateOfBirth.ToShortDateString().HasStringsInCommonWith(dobString))
                .Select(p => p.Guid)
                .ToListAsync();

            if (!patientGuids.Any())
                throw new RepositoryElementNotFoundException(dobString);

            var entities = new List<T>();
            foreach (var guid in patientGuids)
                entities.AddRange(await FindByPatientGuid(guid));

            if (!entities.Any())
                throw new RepositoryElementNotFoundException(dobString);

            return entities;
        }

        private async Task<PatientEntity> GetPatient(Guid patientGuid)
        {
            if (patientGuid == Guid.Empty)
                throw new ArgumentOutOfRangeException($"{nameof(patientGuid)} must not be an empty Guid.");

            try
            {
                return await Context.Patients.FirstAsync(p => p.Guid == patientGuid);
            }
            catch
            {
                throw new RepositoryElementNotFoundException(patientGuid.ToString());
            }
        }

        private async Task<IEnumerable<T>> GetEntitiesAssociatedWithVisit(IEnumerable<VisitEntity> patientVisits, Guid patientGuid)
        {
            var entities = new List<T>();
            foreach (var visit in patientVisits)
                entities.AddRange(await FindByVisit(visit.VisitId));

            if (!entities.Any())
                throw new RepositoryElementNotFoundException(patientGuid.ToString());

            return entities;
        }

        private async Task<IEnumerable<VisitEntity>> GetVisitsAssociatedWithPatient(PatientEntity patient)
        {
            var patientVisits = await Context.Visits.Where(v => v.PatientGuid == patient.Guid).ToListAsync();

            if (!patientVisits.Any())
                throw new RepositoryElementNotFoundException(patient.Guid.ToString());
            
            return patientVisits;
        }
    }
}