using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers.AnalyzablePatientDataControllers
{
    public abstract class VisitDataController : EntityDataController
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        protected readonly IErrorService ErrorService;
        protected readonly IUrlHelper UrlHelper;

        public VisitDataController(IUnitOfWork unitOfWork, IMapper mapper,  IErrorService errorService, IUrlHelper urlHelper) 
        {
            UrlHelper = urlHelper;
            ErrorService = errorService;
            Mapper = mapper;
            UnitOfWork = unitOfWork;
            
        }
    }
}