using System;

namespace GeekMDSuite.WebAPI.Core.Exceptions
{
    public class RepositoryElementNotFoundException : Exception
    {
        public RepositoryElementNotFoundException() : base("Element(s) not located in the repository")
        {
        }
        public RepositoryElementNotFoundException(string element) 
            :base($"{element} could not be located in the repository.")
        {
        }
        public RepositoryElementNotFoundException(int index)
            :base($"An item with index {index} could not be located in the repository.")
        {
        }
    }
}