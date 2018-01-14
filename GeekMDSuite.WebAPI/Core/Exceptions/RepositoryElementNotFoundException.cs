using System;

namespace GeekMDSuite.WebAPI.Core.Exceptions
{
    public class RepositoryElementNotFoundException : Exception
    {
        public RepositoryElementNotFoundException() : base("Element(s) not located in the repository")
        {
        }

        public RepositoryElementNotFoundException(string element)
            : base($"{element} could not be located.")
        {
        }

        public RepositoryElementNotFoundException(int index)
            : base($"{index} could not be located.")
        {
        }
    }
}