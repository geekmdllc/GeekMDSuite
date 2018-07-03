﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.Utilities.Extensions;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class PatientsRepositoryAsync : RepositoryAsync<PatientEntity>, IPatientsRepositoryAsync
    {
        public PatientsRepositoryAsync(GeekMdSuiteDbContext context) : base(context)
        {
        }

        public async Task<PatientEntity> FindByGuid(Guid guid)
        {
            try
            {
                return await Context.Patients.FirstAsync(p => p.PatientGuid == guid);
            }
            catch
            {
                throw new RepositoryEntityNotFoundException(guid.ToString());
            }
        }

        public async Task<IEnumerable<PatientEntity>> FilteredSearch(PatientDataSearchFilter filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            var patients = await Context.Patients.ToListAsync();

            if (filter.BirthDay != null)
                patients.RemoveAll(p => p.DateOfBirth.Day != filter.BirthDay);
            if (filter.BirthMonth != null)
                patients.RemoveAll(p => p.DateOfBirth.Month != filter.BirthMonth);
            if (filter.BirthYear != null)
                patients.RemoveAll(p => p.DateOfBirth.Year != filter.BirthYear);
            if (filter.Name.IsNotNullOrEmpty())
                patients.RemoveAll(p => p.Name.IsNotSimilarTo(filter.Name));
            if (filter.MedicalRecordNumber.IsNotNullOrEmpty())
                patients.RemoveAll(
                    p => p.MedicalRecordNumber.DoesNotHaveStringsInCommonWith(filter.MedicalRecordNumber));

            if (filter.SortOrder == null) return patients;
            return filter.SortOrder == SortOrder.Ascending
                ? patients.OrderBy(p => p.Name.Last)
                : patients.OrderByDescending(p => p.Name.Last);
        }

        public async Task<PatientEntity> FindByVisit(Guid guid)
        {
            if (guid == Guid.Empty)
                throw new ArgumentOutOfRangeException();

            try
            {
                var visit = await Context.Visits.FirstAsync(v => v.VisitGuid == guid);
                return await FindByGuid(visit.PatientGuid);
            }
            catch
            {
                throw new RepositoryEntityNotFoundException(guid.ToString());
            }
        }
    }
}