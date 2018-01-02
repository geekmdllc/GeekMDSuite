using System;

namespace GeekMDSuite.Core.Extensions
{
    public static class DateTimeExtension
    {
        public static int ElapsedYears(this DateTime originalDate)
        {
            return DateTime.Now.Year - originalDate.Year;
        }
    }
}