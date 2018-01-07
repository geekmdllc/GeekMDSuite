using System;

namespace GeekMDSuite.Utilities.Extensions
{
    public static class EnumExtension<T> where T : struct, IConvertible
    {
        public static int CountElements
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