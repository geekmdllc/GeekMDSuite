using System;

namespace GeekMDSuite.Utilities.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsNotNullOrEmtpy(this Guid? guid)
        {
            return guid != Guid.Empty && guid != null;
        }
    }
}