using System;

namespace GeekMDSuite.WebAPI.Core.Exceptions
{
    public class RepositoryElementNotFoundException : Exception
    {
        public RepositoryElementNotFoundException(string element)
        {
            Message = $"Element {element} could not be located in the repository.";
        }
        public RepositoryElementNotFoundException(int index)
        {
            Message = $"An item with index {index} could not be located in the repository.";
        }
        public override string Message { get; }
    }
}