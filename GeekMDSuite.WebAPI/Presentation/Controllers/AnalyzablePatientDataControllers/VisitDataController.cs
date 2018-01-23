using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    public abstract class VisitDataController : EntityDataController
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        protected readonly IErrorService ErrorService;

        public VisitDataController(IUnitOfWork unitOfWork, IMapper mapper,  IErrorService errorService) 
        {
            ErrorService = errorService;
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
        
        protected async Task<IEnumerable<TEntity>> GetFilteredEntities<TEntity>(EntityDataFindFilter filter) where TEntity 
            : class, IMapProperties<TEntity>, IVisitData
        {
            var entities = await UnitOfWork.VisitData<TEntity>().All();
            if (filter == null) return entities;
            if (filter.VisitGuid != null)
                entities = entities.Where(e => e.Guid == filter.VisitGuid);
            if (filter.Offset != null)
                entities = entities.Skip((int) filter.Offset);
            if (filter.Take != null)
                entities = entities.Take((int) filter.Take);

            return entities;
        }
    }
}