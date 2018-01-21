using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Core.Presentation;
using GeekMDSuite.WebAPI.Core.Presentation.ResourceModels;
using GeekMDSuite.WebAPI.DataAccess;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.ResourceModels;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using GeekMDSuite.WebAPI.Presentation.StubModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    public abstract class VisDatCon<TStubFromUser> : Controller where TStubFromUser : class, IVisitData
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;
        protected readonly IUrlHelper UrlHelper;
        protected IErrorService ErrorService;

        public VisDatCon(IUnitOfWork unitOfWork, IMapper mapper, IUrlHelper urlHelper, IErrorService errorService)
        {
            ErrorService = errorService;
            UrlHelper = urlHelper;
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Get()
        {
            try
            {
                var entities = await UnitOfWork.VisitData<BloodPressureEntity>().All();
                var stubs = entities.Select(entity => Mapper.Map<BloodPressureEntity, BloodPressureStub>(entity))
                    .ToList();
                var resources = stubs.Select(stub => new BloodPressureResource
                {
                    Properties = stub,
                    Links = new List<ResourceLink>
                    {
                        new ResourceLink
                        {
                            Description = "Test",
                            Href = UrlHelper.Action<BloodPressureController>(a => a.Get()),
                            HtmlMethods = new List<HtmlMethod> {HtmlMethod.Get},
                            Relationship = UrlRelationship.First
                        }
                    }
                });
                return Ok(resources);
            }
            catch (RepositoryEntityNotFoundException)
            {
                return NotFound();
            }
        }
        public abstract Task<IActionResult> GetById(int id);
        public abstract Task<IActionResult> Post(TStubFromUser entity);
        public abstract Task<IActionResult> Put(int id, TStubFromUser entity);
        public abstract Task<IActionResult> Delete(int id);
    }
    [Produces("application/json", "application/xml")]
    public class BloodPressureController :  VisDatCon<BloodPressureStubFromUser>
    {
//        public override async Task<IActionResult> Get()
//        {
//            try
//            {
//                var entities = await UnitOfWork.VisitData<BloodPressureEntity>().All();
//                var stubs = entities.Select(entity => Mapper.Map<BloodPressureEntity, BloodPressureStub>(entity)).ToList();
//                var resources = stubs.Select(stub => new BloodPressureResource
//                {
//                    Properties = stub,
//                    Links = new List<ResourceLink>
//                    {
//                        new ResourceLink
//                        {
//                            Description = "Test",
//                            Href = UrlHelper.Action<BloodPressureController>(a => a.Get()),
//                            HtmlMethods = new List<HtmlMethod> { HtmlMethod.Get },
//                            Relationship = UrlRelationship.First
//                        }
//                    }
//                });
//                return Ok(resources);
//            }
//            catch (RepositoryEntityNotFoundException)
//            {
//                return NotFound();
//            }
//        }

        public override Task<IActionResult> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Post(BloodPressureStubFromUser entity)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Put(int id, BloodPressureStubFromUser entity)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BloodPressureController(IUnitOfWork unitOfWork, IMapper mapper, IUrlHelper urlHelper, IErrorService errorService) : base(unitOfWork, mapper, urlHelper, errorService)
        {
        }
    }

    public interface IVisitDataController<in TStubFromUser> where TStubFromUser : class, IVisitData
    {
        Task<IActionResult> Get();
        Task<IActionResult> Get(int id);
        Task<IActionResult> Post(TStubFromUser entity);
        Task<IActionResult> Put(int id, TStubFromUser entity);
        Task<IActionResult> Delete(int id);
    }
}