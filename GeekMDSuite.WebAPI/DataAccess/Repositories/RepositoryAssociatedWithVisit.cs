using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Helpers;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class RepositoryAssociatedWithVisit<T> : Repository<T>, IRepositoryAssociatedWithVisit<T> 
        where T : class, IVisitData<T>
    {
        public RepositoryAssociatedWithVisit(GeekMdSuiteDbContext context) : base (context) {}

        public IEnumerable<T> FindByVisit(Guid visitGuid)
        {
            if (visitGuid == Guid.Empty) 
                throw new ArgumentOutOfRangeException($"{nameof(visitGuid)} must not be an empty Guid.");

            var result = Context.Set<T>().Where(v => v.Visit == visitGuid);
            
            if (!result.Any())
                throw new RepositoryElementNotFoundException(visitGuid.ToString());

            return result;
        }
        
        public IEnumerable<T> FindByPatientGuid(Guid patientGuid)
        {
            if (patientGuid == Guid.Empty) 
                throw new ArgumentOutOfRangeException($"{nameof(patientGuid)} must not be an empty Guid.");
            
            var visitsList = Context.Visits.Where(v => v.PatientGuid == patientGuid).ToList();
            if (!visitsList.Any())
                throw new RepositoryElementNotFoundException(patientGuid.ToString());

            if (typeof(T) == typeof(VisitEntity))
                return visitsList as IEnumerable<T>;
            
            var results = new List<T>();
            foreach (var visit in visitsList)
                results.AddRange(FindByVisit(visit.Visit));

            if (!results.Any())
                throw new RepositoryElementNotFoundException(patientGuid.ToString());
            
            return results;
        }
 
        public IEnumerable<T> FindByMedicalRecordNumber(string mrn)
        {
            if (string.IsNullOrEmpty(mrn)) 
                throw new ArgumentNullException(mrn);
            
            var patientGuids = Context.Patients.Where(p => p.MedicalRecordNumber.IsEqualTo(mrn)) .Select(p => p.Guid);
            
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

            var patientGuids = Context.Patients.Where(p => p.Name.IsSimilarTo(name)) .Select(p => p.Guid);
            
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
            if (dateOfBirth.IsInvalidAge())
                throw new ArgumentOutOfRangeException(dateOfBirth.ToShortDateString());

            var dobString = dateOfBirth.ToShortDateString();            
            var patientGuids = Context.Patients.Where(p => p.DateOfBirth.ToShortDateString().HasStringsInCommonWith(dobString)).Select(p => p.Guid);
            
            if (!patientGuids.Any())
                throw new RepositoryElementNotFoundException(dobString);

            var entities = new List<T>();
            foreach (var guid in patientGuids)
                entities.AddRange(FindByPatientGuid(guid));

            if (!entities.Any())
                throw new RepositoryElementNotFoundException(dobString);

            return entities;
        }
    }
}