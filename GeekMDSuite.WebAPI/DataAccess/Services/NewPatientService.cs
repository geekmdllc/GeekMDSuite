using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekMDSuite.Core.Models;
using GeekMDSuite.Utilities.Extensions;
using GeekMDSuite.WebAPI.Core.DataAccess.Services;
using GeekMDSuite.WebAPI.Core.Exceptions;
using GeekMDSuite.WebAPI.Presentation.EntityModels;

namespace GeekMDSuite.WebAPI.DataAccess.Services
{
    public class NewPatientService : NewKeyEntityService<PatientEntity, Patient>, INewPatientService
    {
        public override async Task<PatientEntity> UsingTemplatePatient(Patient patient)
        {
            VerifyContextIsLoaded();
            ValidatePatientFormat(patient);
            await MedicalRecordNumberAlreadyExists(patient);

            var newPatient = new PatientEntity();
            newPatient.MapValues(patient);
            newPatient.Guid = Guid.NewGuid();

            return newPatient;
        }

        private static void ValidatePatientFormat(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));

            var message = new List<string>();

            if (patient.Name.IsMissingFirstOrLast())
                message.Add("Name");
            if (patient.MedicalRecordNumber.IsEmpty())
                message.Add("MedicalRecordNumber");
            if (patient.DateOfBirth.IsOutOfRange())
                message.Add("DateOfBirth");

            if (message.Any()) throw new FormatException(string.Join(", ", message));
        }

        private async Task MedicalRecordNumberAlreadyExists(Patient patient)
        {
            var mrnExists = false;
            try
            {
                var patients = await UnitOfWork.Patients.All();
                if (patients.Any(p => p.MedicalRecordNumber == patient.MedicalRecordNumber))
                    mrnExists = true;
            }
            catch
            {
                mrnExists = false;
            }

            if (mrnExists) throw new MedicalRecordAlreadyExistsException(patient.MedicalRecordNumber);
        }
    }
}