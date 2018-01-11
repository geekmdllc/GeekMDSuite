using System.Threading.Tasks;
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
        protected IUnitOfWork UnitOfWork;
        private bool ContextNotLoaded => UnitOfWork == null;

        public INewKeyEntityService<TObject, TTemplate> WithUnitOfWork(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            return this;
        }

        public abstract Task<TObject> UsingTemplatePatient(TTemplate template);

        protected void VerifyContextIsLoaded()
        {
            if (ContextNotLoaded) throw new UnitOfWorkNotLoadedException(nameof(NewVisitService));
        }
    }
}