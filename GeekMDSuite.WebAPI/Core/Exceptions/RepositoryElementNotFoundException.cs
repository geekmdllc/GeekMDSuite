using System;

namespace GeekMDSuite.WebAPI.Core.Exceptions
{
    public class RepositoryElementNotFoundException : Exception
    {
        public RepositoryElementNotFoundException(string element)
        {
            Message = $"{element} could not be located in the repository.";
        }
        public override string Message { get; }
    }
}