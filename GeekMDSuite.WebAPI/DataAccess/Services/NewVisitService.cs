using System;
using System.IO;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Services
{
    public class NewVisitService : NewKeyEntityService<VisitEntity, VisitEntity>, INewVisitService
    {
        public override VisitEntity GenerateUsing(VisitEntity template)
        {
            if (template == null) throw new ArgumentNullException(nameof(template));
            if (template.PatientGuid == Guid.Empty) 
                throw new InvalidDataException($"{nameof(GenerateUsing)} must receive a {nameof(VisitEntity)} with a valid PatientGuid.");
            VerifyContextIsLoaded();
            return new VisitEntity(template) { Visit = Guid.NewGuid() };
        }
    }
}