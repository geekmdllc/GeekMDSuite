using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories.EntityData;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Core.Presentation;
using GeekMDSuite.WebAPI.Presentation.ResourceModels;
using Microsoft.AspNetCore.Mvc;

namespace GeekMDSuite.WebAPI.Presentation.Controllers
{
    [Produces("application/json", "application/xml")]
    public abstract class VisitDataController<TEntity, TResourceStub, TResourceStubFromUser, TResource, TController> 
        : EntityDataController<TEntity, TResourceStubFromUser>
        where TEntity : class, IMapProperties<TEntity>, Core.Models.IVisitData, new()
        where TResourceStub : IVisitData
        where TResourceStubFromUser : IVisitData
        where TResource : Resource<TResourceStub>, new()
        where TController : VisitDataController<TEntity, TResourceStub, TResourceStubFromUser, TResource, TController>
    {
        private readonly IRepositoryAssociatedWithVisitAsync<TEntity> _repo;
        private readonly IUrlHelper _urlHelper;

        protected VisitDataController(IUnitOfWork unitOfWork, IMapper mapper, IUrlHelper urlHelper) : base(unitOfWork, mapper)
        {
            _urlHelper = urlHelper;
            _repo = UnitOfWork.VisitData<TEntity>();
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                var entities = await _repo.All();
                var stubs = entities.Select(entity => Mapper.Map<TEntity, TResourceStub>(entity)).ToList();
                var resources = stubs.Select(stub => new TResource
                {
                    Properties = stub,
                    Links = GenerateGetAllLinks()
                });
                return Ok(resources);
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByPrimaryKey(int id) 
        {
            try
            {
                var entity = await _repo.FindById(id);
                var stub = Mapper.Map<TEntity, TResourceStub>(entity);
                var resource = new TResource
                {
                    Properties = stub,
                    Links = GenerateGetByPrimaryKeyLinks(stub)
                };
                return Ok(resource);
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound($"Cannot locate element with id {id}.");
            }
        }

        private List<ResourceLink> GenerateGetByPrimaryKeyLinks(TResourceStub stub)
        {
            return new List<ResourceLink>
            {
                new ResourceLink
                {
                    Description = "Get this item.",
                    Href = _urlHelper.Action($"{nameof(GetByPrimaryKey)}"),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Self
                },
                new ResourceLink
                {
                    Description = "View visit for this item.",
                    Href = _urlHelper.Action<VisitController>(a => a.GetByGuid(stub.Guid)),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Prev
                }
            };
        }


        private List<ResourceLink> GenerateGetAllLinks()
        {
            return new List<ResourceLink>
            {
                new ResourceLink
                {
                    Description = "Get all.",
                    Href = _urlHelper.Action($"{nameof(GetAll)}"),
                    HtmlMethod = HtmlMethod.Post,
                    Relationship = UrlRelationship.Self
                },
                new ResourceLink
                {
                    Description = "Get all visits.",
                    Href = _urlHelper.Action<VisitController>(a => a.GetBySearch(null)),
                    HtmlMethod = HtmlMethod.Get,
                    Relationship = UrlRelationship.Prev
                }
            };
        }
    }
}