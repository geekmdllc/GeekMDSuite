using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.Utilities.Extensions;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class PatientsRepository : Repository<PatientEntity>, IPatientsRepository
    {
        public PatientsRepository(GeekMdSuiteDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PatientEntity>> FindByName(string query)
        {
            if (query.IsEmpty()) throw new ArgumentNullException(query);
            
            var result = await Context.Patients.Where(p => p.Name.IsSimilarTo(query)).ToListAsync();
            if (!result.Any()) throw new RepositoryElementNotFoundException(query);

            return result;
        }

        public async Task<IEnumerable<PatientEntity>> FindByMedicalRecordNumber(string query)
        {
            if (query.IsEmpty()) throw new ArgumentNullException(query);
            
            var result = await Context.Patients.Where(p => query.IsEqualTo(p.MedicalRecordNumber)).ToListAsync();
            if (!result.Any()) throw new RepositoryElementNotFoundException(query);

            return result;
        }


        public async Task<IEnumerable<PatientEntity>> FindByDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth.IsOutOfRange())
                throw new ArgumentOutOfRangeException(dateOfBirth.ToShortDateString());

            var found = await Context.Patients.Where(
                p => p.DateOfBirth.ToShortDateString() == dateOfBirth.ToShortDateString()).ToListAsync();

            if (!found.Any())
                throw new RepositoryElementNotFoundException(dateOfBirth.ToShortDateString());

            return found;
        }

        public async Task<PatientEntity> FindByGuid(Guid guid)
        {
            if (guid == Guid.Empty)
                throw new ArgumentOutOfRangeException(guid.ToString());
            try
            {
                return await Context.Patients.FirstAsync(p => p.Guid == guid);
            }
            catch (InvalidOperationException)
            {
                throw new RepositoryElementNotFoundException(guid.ToString());
            }
        }
    }
}