using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Core;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Core.Helpers;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Services
{
    public class NewPatientService :  NewKeyEntityService<PatientEntity, Patient>, INewPatientService
    {
  
        public override PatientEntity GenerateUsing(Patient patient)
        {
            VerifyContextIsLoaded();
            
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            ValidatePatientFormat(patient);
            EnsureMedicalRecordNumberIsUnique(patient);
            
            return new PatientEntity(patient) { Guid = Guid.NewGuid() };
        }

        private static void ValidatePatientFormat(Patient patient)
        {
            var message = new List<string>();
            
            if (patient.Name.IsMalformed()) 
                message.Add("Name");
            if (patient.MedicalRecordNumber.IsEmpty()) 
                message.Add("MedicalRecordNumber");
            if (patient.DateOfBirth.IsInvalidAge()) 
                message.Add("DateOfBirth");
            
            if(message.Any()) throw new FormatException(string.Join(", ", message));
        }

        private void EnsureMedicalRecordNumberIsUnique(Patient patient)
        {
            if (UnitOfWork.Patients.MedicalRecordNumberExists(patient.MedicalRecordNumber)) 
                throw new MedicalRecordNotUniqueException(patient.MedicalRecordNumber);
        }

    }
}