using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Presentation;
using GeekMDSuite.WebAPI.Presentation.EntityModels;
using GeekMDSuite.WebAPI.Presentation.ResourceStubModels;

namespace GeekMDSuite.WebAPI.DataAccess.Services
{
    public class NewVisitService : NewKeyEntityService<VisitEntity, VisitEntity>, INewVisitService
    {

        public override async Task<VisitEntity> UsingTemplatePatientEntity(VisitEntity template)
        {
            VerifyContextIsLoaded();
            if (template == null) throw new ArgumentNullException(nameof(template));
            if (template.PatientGuid == Guid.Empty)
                throw new InvalidDataException($"{nameof(UsingTemplatePatientEntity)} must receive a {nameof(VisitEntity)} with a valid PatientGuid.");

            var newVisitEntity = new VisitEntity
            {
                Guid = Guid.NewGuid(),
                Status = VisitStatus.Scheduled
            };

            return newVisitEntity;
        }
    }
}