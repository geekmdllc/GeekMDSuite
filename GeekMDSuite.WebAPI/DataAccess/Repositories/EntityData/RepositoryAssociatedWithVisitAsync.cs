using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class RepositoryAssociatedWithVisitAsync<TEntity> : RepositoryAsync<TEntity>, IRepositoryAssociatedWithVisitAsync<TEntity>
        where TEntity : class, IMapProperties<TEntity>, IVisitData
    {
        public RepositoryAssociatedWithVisitAsync(GeekMdSuiteDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TEntity>> FindByVisit(Guid visitGuid)
        {
            if (visitGuid == Guid.Empty)
                throw new ArgumentOutOfRangeException($"{nameof(visitGuid)} must not be an empty Guid.");

            var result = await Context.Set<TEntity>().Where(set => set.Guid == visitGuid).ToListAsync();

            if (!result.Any())
                throw new RepositoryEntityNotFoundException(visitGuid.ToString());

            return result;
        }
        
        public async Task<IEnumerable<TEntity>> FindByPatient(Guid paitentGuid)
        {
            var patients = await Context.Patients.Where(patient => patient.Guid == paitentGuid).ToListAsync();
            var patientVisits = new List<VisitEntity>();
            foreach (var patient in patients)
                patientVisits.AddRange(await Context.Visits.Where(v => v.PatientGuid == patient.Guid).ToListAsync());

            var entities = new List<TEntity>();
            foreach (var patientVisit in patientVisits)
                entities.AddRange(await Context.Set<TEntity>().Where(v => v.Guid == patientVisit.Guid).ToListAsync());

            return entities;
        }
    }
}