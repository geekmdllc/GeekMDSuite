using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.Utilities.Extensions;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Core.Presentation;
using GeekMDSuite.WebAPI.Core.Presentation.ResourceModels;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.ResourceModels;
using GeekMDSuite.WebAPI.Presentation.StubFromUserModels;
using GeekMDSuite.WebAPI.Presentation.StubModels;
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
    [Produces("application/json", "application/xml")]
    public class BloodPressureController : VisitDataController
    {
        
        public BloodPressureController(IUnitOfWork unitOfWork, IMapper mapper, IErrorService errorService, IUrlHelper urlHelper) : base(unitOfWork, mapper, errorService, urlHelper)
        {
        }

        public async Task<IActionResult> GetBySearch(EntityDataFindFilter filter)
        {
            var entities = await GetFilteredBloodPressureEntities(filter);
            
            var resources = GenerateBloodPressureResources(entities);

            return Ok(resources);
        }

        public async Task<IActionResult> GetById(int id)
        {
            var entity = await UnitOfWork.BloodPressures.FindById(id);
            var stub = Mapper.Map<BloodPressureEntity, BloodPressureStub>(entity);
            var resource = new BloodPressureResource
            {
                Links = GenerateGetByIdLinks(id),
                Properties = stub
            };

            return Ok(resource);
        }

        private List<ResourceLink> GenerateGetByIdLinks(int id)
        {
            return new List<ResourceLink>
            {
                new ResourceLink
                {
                    Description = "Get blood pressure resource by it's unique identifier.",
                    Href = UrlHelper.Action<BloodPressureController>(a => a.GetById(id)),
                    HtmlMethods = new List<HtmlMethod> {HtmlMethod.Get},
                    Relationship = UrlRelationship.Self
                },
                new ResourceLink
                {
                    Description = "Search for blood pressures resources with filters and pagination",
                    Href = UrlHelper.Action<BloodPressureController>(a => a.GetBySearch(null)),
                    HtmlMethods = new List<HtmlMethod> {HtmlMethod.Get},
                    Relationship = UrlRelationship.Search
                },
                new ResourceLink
                {
                    Description = "Go to the application data root",
                    Href = UrlHelper.Action<DataController>(a => a.Get()),
                    HtmlMethods = new List<HtmlMethod> {HtmlMethod.Get},
                    Relationship = UrlRelationship.Up
                }
            };
        }

        public async Task<IActionResult> Post([FromBody] BloodPressureStubFromUser stub)
        {
            var entity = Mapper.Map<BloodPressureStubFromUser, BloodPressureEntity>(stub);
            await UnitOfWork.BloodPressures.Add(entity);
            var url = UrlHelper.Action<BloodPressureController>(a => a.Post(stub));
            return Created(url, entity);
        }

        public async Task<IActionResult> Put(int id, [FromBody] BloodPressureStubFromUser stub)
        {
            var entity = Mapper.Map<BloodPressureStubFromUser, BloodPressureEntity>(stub);
            await UnitOfWork.BloodPressures.Update(entity);
            return Ok(stub);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await UnitOfWork.BloodPressures.Delete(id);
            return NoContent();
        }

        private List<ResourceLink> GenerateLinksForGetBySearch(IEntity stub)
        {
            return new List<ResourceLink>
            {
                new ResourceLink
                {
                    Description = "Get this blood pressure resource",
                    Href = UrlHelper.Action<BloodPressureController>(a => a.GetById(stub.Id)),
                    HtmlMethods = new List<HtmlMethod> {HtmlMethod.Get},
                    Relationship = UrlRelationship.Next
                },
                new ResourceLink
                {
                    Description = "Go to the application data root",
                    Href = UrlHelper.Action<DataController>(a => a.Get()),
                    HtmlMethods = new List<HtmlMethod> {HtmlMethod.Get},
                    Relationship = UrlRelationship.Up
                }
            };
        }
                
        private async Task<IEnumerable<BloodPressureEntity>> GetFilteredBloodPressureEntities(EntityDataFindFilter filter)
        {
            var entities = await UnitOfWork.BloodPressures.All();
            if (filter == null) return entities;
            if (filter.VisitGuid != null)
                entities = entities.Where(e => e.Guid == filter.VisitGuid);
            if (filter.Offset != null)
                entities = entities.Skip((int) filter.Offset);
            if (filter.Take != null)
                entities = entities.Take((int) filter.Take);

            return entities;
        }
        
        private IEnumerable<BloodPressureResource> GenerateBloodPressureResources(IEnumerable<BloodPressureEntity> entities)
        {
            var stubs = entities.Select(Mapper.Map<BloodPressureEntity, BloodPressureStub>);
            var resources = stubs.Select(stub => new BloodPressureResource
            {
                Links = GenerateLinksForGetBySearch(stub),
                Properties = stub
            });
            return resources;
        }
    }

    public class EntityDataFindFilter
    {
        public Guid? VisitGuid { get; set; }
        public int? Offset { get; set; }
        public int? Take { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if (VisitGuid.IsNotNullOrEmtpy()) builder.Append($"{nameof(VisitGuid)}={VisitGuid}");
            if (Offset != null) builder.Append($"{nameof(Offset)}={Offset}");
            if (Take != null) builder.Append($"{nameof(Take)}={Take}");

            return string.Join("&", builder);
        }
    }
}