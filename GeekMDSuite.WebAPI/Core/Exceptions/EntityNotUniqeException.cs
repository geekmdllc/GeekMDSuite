using System;

namespace GeekMDSuite.WebAPI.Core.Exceptions
{
    public class EntityNotUniqeException : Exception
    {
        public EntityNotUniqeException(int id)
            : base($"Entity with id {id} already exists.")
        {
        }
    }
}