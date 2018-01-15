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
        where TEntity : class, IVisitData<TEntity>, new()
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
            return await GetAllForCurrentController();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByPrimaryKey(int id) 
        {
            return await GetByPrimaryKeyForCurrentController(id);
        }

        private async Task<IActionResult> GetByPrimaryKeyForCurrentController(int id)
        {
            try
            {
                var entity = await _repo.FindById(id);
                var stub = Mapper.Map<TEntity, TResourceStub>(entity);
                var resource = new TResource
                {
                    Properties = stub,
                    Links = new List<ResourceLink>
                    {
                        new ResourceLink
                        {
                            Description = "Description",
                            Href = _urlHelper.Action<TController>(p => p.GetAll()),
                            HtmlMethod = HtmlMethod.Post,
                            Relationship = UrlRelationship.Self
                        }
                    }
                };
                return Ok(resource);
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound($"Cannot locate element with id {id}.");
            }
        }

        private async Task<IActionResult> GetAllForCurrentController() 
        {
            try
            {
                var entities = await _repo.All();
                var stubs = entities.Select(entity => Mapper.Map<TEntity, TResourceStub>(entity)).ToList();
                var resources = stubs.Select(stub => new TResource
                {
                    Properties = stub,
                    Links = new List<ResourceLink>
                    {
                        new ResourceLink
                        {
                            Description = "Description",
                            Href = _urlHelper.Action<TController>(p => p.GetAll()),
                            HtmlMethod = HtmlMethod.Post,
                            Relationship = UrlRelationship.Self
                        }
                    }
                });
                return Ok(resources);
            }
            catch (RepositoryElementNotFoundException)
            {
                return NotFound();
            }
        }
    }
}