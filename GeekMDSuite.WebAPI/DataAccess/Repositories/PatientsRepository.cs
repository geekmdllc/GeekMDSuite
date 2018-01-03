﻿using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Helpers;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories
{
    public class PatientsRepository : Repository<PatientEntity>, IPatientsRepository
    {
        public PatientsRepository(GeekMdSuiteDbContext context) : base(context)
        {
        }

        public IEnumerable<PatientEntity> FindByName(string query)
        {
            if (query.IsEmpty()) throw new ArgumentNullException(query);
            var result = Context.Patients.Where(p => query.HasStringsInCommonWith(p.Name.ToString()));
            if (!result.Any()) throw new RepositoryElementNotFoundException(query);

            return result;
        }

        public IEnumerable<PatientEntity> FindByMedicalRecordNumber(string query)
        {
            if (query.IsEmpty()) throw new ArgumentNullException(query);
            var result = Context.Patients.Where(p => query.IsEqualTo(p.MedicalRecordNumber));
            if (!result.Any()) throw new RepositoryElementNotFoundException(query);

            return result;
        }


        public IEnumerable<PatientEntity> FindByDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth.IsOutOfRange())
                throw new ArgumentOutOfRangeException(dateOfBirth.ToShortDateString());

            var found = Context.Patients.Where(
                p => p.DateOfBirth.ToShortDateString() == dateOfBirth.ToShortDateString());
            
            if (!found.Any())
                throw new RepositoryElementNotFoundException(dateOfBirth.ToShortDateString());

            return found;
        }

        public PatientEntity FindByGuid(Guid guid)
        {
            if (guid == Guid.Empty)
                throw new ArgumentOutOfRangeException(guid.ToString());
            try
            {
                return Context.Patients.First(p => p.Guid == guid);
            }
            catch (InvalidOperationException)
            {
                throw new RepositoryElementNotFoundException(guid.ToString());
            }
        }
    }
}