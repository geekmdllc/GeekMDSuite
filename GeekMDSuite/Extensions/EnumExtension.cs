using System;

namespace GeekMDSuite.Extensions
{
    internal static class EnumExtension<T> where T : struct, IConvertible
    {
        internal static int Count
        {
            get
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("T must be an enumerated type");

                return Enum.GetNames(typeof(T)).Length;
            }
        }
    }
}