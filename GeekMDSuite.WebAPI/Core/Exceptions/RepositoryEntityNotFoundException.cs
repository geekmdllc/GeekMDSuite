using System;

namespace GeekMDSuite.WebAPI.Core.Exceptions
{
    public class RepositoryEntityNotFoundException : Exception
    {
        public RepositoryEntityNotFoundException() : base("Element(s) not located in the repository")
        {
        }

        public RepositoryEntityNotFoundException(string element)
            : base($"{element} could not be located.")
        {
        }

        public RepositoryEntityNotFoundException(int index)
            : base($"{index} could not be located.")
        {
        }
    }
}