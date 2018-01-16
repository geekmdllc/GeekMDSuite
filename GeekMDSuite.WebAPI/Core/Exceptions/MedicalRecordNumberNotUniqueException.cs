using System;

namespace GeekMDSuite.WebAPI.Core.Exceptions
{
    public class MedicalRecordNumberNotUniqueException : Exception
    {
        public MedicalRecordNumberNotUniqueException(string mrn)
            : base($"{mrn} is not unique. Please verify before resubmitting request")
        {
        }
    }
}