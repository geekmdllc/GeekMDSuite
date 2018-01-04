using System;

namespace GeekMDSuite.WebAPI.Core.Exceptions
{
    public class MedicalRecordAlreadyExistsException : Exception
    {
        public MedicalRecordAlreadyExistsException(string mrn)
            : base($"{mrn} is not unique. Please verify before resubmitting request")
        {
        }
    }
}