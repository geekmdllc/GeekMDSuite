using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace GeekMDSuite.WebAPI.DataAccess.Services
{
    public class NewVisitService : NewKeyEntityService<VisitEntity, VisitEntity>, INewVisitService
    {
        public NewVisitService()
        {
            
        }

        public override VisitEntity GenerateUsing(VisitEntity template)
        {
            if (template == null) throw new ArgumentNullException(nameof(template));
            
            VerifyContextIsLoaded();
            return new VisitEntity(template) { Visit = Guid.NewGuid() };
        }
    }
}