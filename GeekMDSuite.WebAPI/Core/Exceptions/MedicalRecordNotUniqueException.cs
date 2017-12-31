using System;

namespace GeekMDSuite.WebAPI.Core.Exceptions
{
    public class MedicalRecordNotUniqueException : Exception
    {
        public MedicalRecordNotUniqueException(string mrn)
        {
            Message = $"{mrn} is not unique. Please verify before resubmitting request";
        }
        public override string Message { get; }
    }
}