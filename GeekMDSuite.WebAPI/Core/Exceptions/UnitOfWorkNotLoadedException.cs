using System;

namespace GeekMDSuite.WebAPI.Core.Exceptions
{
    public class UnitOfWorkNotLoadedException : Exception
    {
        public UnitOfWorkNotLoadedException(string service)
        {
            Message = $"{service} needs to have a context loaded before generating a new object.";
        }

        public override string Message { get; }
    }
}