using System;

namespace GeekMDSuite.WebAPI.Core.Exceptions
{
    public class EntityNotUniqeException : Exception
    {
        public EntityNotUniqeException(int id)
        {
            Message = $"Entity with id {id} already exists.";
        }

        public override string Message { get; }
    }
}