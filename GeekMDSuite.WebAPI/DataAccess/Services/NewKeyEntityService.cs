using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.DataAccess.Services
{
    public abstract class NewKeyEntityService<TObject, TTemplate> : INewKeyEntityService<TObject, TTemplate> 
        where TObject : class, IEntity<TObject> 
        where TTemplate : class
    {
        public INewKeyEntityService<TObject, TTemplate> WithUnitOfWork(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            return this;
        }

        public abstract TObject GenerateUsing(TTemplate template);
        
        protected IUnitOfWork UnitOfWork;
        private bool ContextNotLoaded => UnitOfWork == null;

        protected void VerifyContextIsLoaded()
        {
            if (ContextNotLoaded) throw new UnitOfWorkNotLoadedException(nameof(NewVisitService));
        }
    }
}