using System;
using GeekMDSuite.Core;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Services
{
    public class NewPatientService :  NewKeyEntityService<PatientEntity, Patient>, INewPatientService
    {
  
        public override PatientEntity GenerateUsing(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            
            VerifyContextIsLoaded();
            EnsureMedicalRecordNumberIsUnique(patient);
            return new PatientEntity(patient) { Guid = Guid.NewGuid() };
        }

        private void EnsureMedicalRecordNumberIsUnique(Patient patient)
        {
            if (UnitOfWork.Patients.MedicalRecordNumberExists(patient.MedicalRecordNumber)) 
                throw new MedicalRecordNotUniqueException(patient.MedicalRecordNumber);
        }

    }
}