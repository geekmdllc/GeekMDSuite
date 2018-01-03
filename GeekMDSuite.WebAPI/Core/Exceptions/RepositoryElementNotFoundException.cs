using System;

namespace GeekMDSuite.WebAPI.Core.Exceptions
{
    public class RepositoryElementNotFoundException : Exception
    {
        public RepositoryElementNotFoundException()
        {
            Message = "Element(s) not located in the repository";
        }
        public RepositoryElementNotFoundException(string element)
        {
            Message = $"{element} could not be located in the repository.";
        }
        public RepositoryElementNotFoundException(int index)
        {
            Message = $"An item with index {index} could not be located in the repository.";
        }
        public override string Message { get; }
    }
}