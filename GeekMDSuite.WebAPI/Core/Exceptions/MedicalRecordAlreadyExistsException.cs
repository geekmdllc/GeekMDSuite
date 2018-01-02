using System;

namespace GeekMDSuite.WebAPI.Core.Exceptions
{
    public class MedicalRecordAlreadyExistsException : Exception
    {
        public MedicalRecordAlreadyExistsException(string mrn)
        {
            Message = $"{mrn} is not unique. Please verify before resubmitting request";
        }
        public override string Message { get; }
    }
}