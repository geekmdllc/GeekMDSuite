using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Services
{
    public class NewVisitService : NewKeyEntityService<VisitEntity, VisitEntity>, INewVisitService
    {
        public NewVisitService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override VisitEntity GenerateUsing(VisitEntity template) => new VisitEntity(template)
        {
            Visit = Guid.NewGuid()
        };
    }
}