using System;
using GeekMDSuite.WebAPI.Core.DataAccess;

namespace GeekMDSuite.WebAPI.Core.Exceptions
{
    public class UnitOfWorkNotLoadedException : Exception
    {
        public UnitOfWorkNotLoadedException(string service)
        {
            Message = $"{service} must have an {nameof(IUnitOfWork)} loaded before generating a new object.";
        }

        public override string Message { get; }
    }
}