using System;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Repositories;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Services
{
    public class NewPatientService :  INewPatientService
    {
        public NewPatientService(IUnitOfWork unitOfWork)
        {
            _patients = unitOfWork.Patients;
        }

        public PatientEntity GenerateUsing(Patient patient)
        {
            EnsureMedicalRecordNumberIsUnique(patient.MedicalRecordNumber);
            
            return new PatientEntity(patient)
            {
                Guid = Guid.NewGuid()  
            };
        }
        
        private readonly IPatientsRepository _patients;

        private void EnsureMedicalRecordNumberIsUnique(string mrn)
        {
            if (_patients.MedicalRecordNumberExists(mrn)) 
                throw new MedicalRecordNotUniqueException(mrn);
        }

    }
}