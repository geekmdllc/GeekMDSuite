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
            if (filter == null) throw new ArgumentNullException(nameof(filter));
            
            var patients = await Context.Patients.ToListAsync();

            if (filter.MedicalRecordNumber.IsNotNullOrEmpty())
                patients.RemoveAll(p => p.MedicalRecordNumber.DoesNotContain(filter.MedicalRecordNumber));
            if (filter.Name.IsNotNullOrEmpty())
                patients.RemoveAll(p => p.Name.IsNotSimilarTo(filter.Name));
            if (filter.PatientGuid.IsNotNullOrEmtpy())
                patients.RemoveAll(p => p.Guid != filter.PatientGuid);

            var found = new List<VisitEntity>();
            foreach (var patient in patients)
                found.AddRange(await FindByPatient(patient.Guid));

            if (filter.VisitDay != null)
                found.RemoveAll(p => p.Date.Day != filter.VisitDay);
            if (filter.VisitMonth != null)
                found.RemoveAll(p => p.Date.Month != filter.VisitMonth);
            if (filter.VisitYear != null)
                found.RemoveAll(p => p.Date.Year != filter.VisitYear);

            if (filter.SortOrder == null) return found;
            return filter.SortOrder == SortOrder.Ascending ? found.OrderBy(v => v.Date) : found.OrderByDescending(v => v.Date);
        }

        public async Task<VisitEntity> FindByGuid(Guid guid)
        {
            return await Context.Visits.FirstAsync(v => v.Guid == guid);
        }

        public async Task<IEnumerable<VisitEntity>> FindByPatient(Guid guid)
        {
            return await Context.Visits.Where(v => v.PatientGuid == guid).ToListAsync();
        }
    }
}