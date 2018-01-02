using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.DataAccess.Services
{
    public abstract class NewKeyEntityService<TObject, TTemplate> : INewKeyEntityService<TObject, TTemplate> 
        where TObject : class, IEntity<TObject> 
        where TTemplate : class
    {
        protected NewKeyEntityService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public abstract TObject GenerateUsing(TTemplate template);
        
        
        protected readonly IUnitOfWork UnitOfWork;
    }
}