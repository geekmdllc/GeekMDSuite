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
        public NewPatientService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
  
        public override PatientEntity GenerateUsing(Patient patient)
        {
            EnsureMedicalRecordNumberIsUnique(patient.MedicalRecordNumber);
            
            return new PatientEntity(patient)
            {
                Guid = Guid.NewGuid()  
            };
        }

        private void EnsureMedicalRecordNumberIsUnique(string mrn)
        {
            if (UnitOfWork.Patients.MedicalRecordNumberExists(mrn)) 
                throw new MedicalRecordNotUniqueException(mrn);
        }

    }
}