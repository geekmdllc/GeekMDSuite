using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.Utilities.Extensions;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.Filters;
using GeekMDSuite.WebAPI.DataAccess.Context;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace GeekMDSuite.WebAPI.DataAccess.Repositories.EntityData
{
    public class VisitsRepositoryAsync : RepositoryAsync<VisitEntity>, IVisitsRepositoryAsync
    {
        public VisitsRepositoryAsync(GeekMdSuiteDbContext context) : base(context)
        {
            
            
        }

        public async Task<IEnumerable<VisitEntity>> FilteredSearch(VisitDataSearchFilter filter)
        {
            var patients = await Context.Patients.ToListAsync();
            if (filter.SortOrder == SortOrder.Ascending)

            if (!string.IsNullOrWhiteSpace(filter.MedicalRecordNumber))
                patients.RemoveAll(p => !p.MedicalRecordNumber.Contains(filter.MedicalRecordNumber));
            if (!string.IsNullOrWhiteSpace(filter.Name))
                patients.RemoveAll(p => !p.Name.IsSimilarTo(filter.Name));
            if (filter.PatientGuid != Guid.Empty && filter.PatientGuid != null)
                patients.RemoveAll(p => p.Guid != filter.PatientGuid);

            var found = new List<VisitEntity>();
            foreach (var patient in patients)
                found.AddRange(await Context.Visits.Where(v => v.PatientGuid == patient.Guid).ToListAsync());
            
            if (filter.VisitDay != null)
                found.RemoveAll(p => p.Date.Day != filter.VisitDay);
            if (filter.VisitMonth != null)
                found.RemoveAll(p => p.Date.Month != filter.VisitMonth);
            if (filter.VisitYear != null)
                found.RemoveAll(p => p.Date.Year != filter.VisitYear);

            if (filter.SortOrder == null) return found;
            return filter.SortOrder == SortOrder.Ascending 
                ? found.OrderBy(v => v.Date) 
                : found.OrderByDescending(v => v.Date);
        }

        public async Task<VisitEntity> FindByGuid(Guid guid) 
            => await Context.Visits.FirstAsync(v => v.Guid == guid);
        
        public async Task<IEnumerable<VisitEntity>> FindByPatient(Guid guid) 
            => await Context.Visits.Where(v => v.PatientGuid == guid).ToListAsync();
    }
}