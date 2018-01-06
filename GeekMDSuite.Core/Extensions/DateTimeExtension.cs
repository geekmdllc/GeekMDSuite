using System;

namespace GeekMDSuite.Core.Extensions
{
    public static class DateTimeExtension
    {
        public static int ElapsedYears(this DateTime originalDate)
        {
            return originalDate.ElapsedYears(DateTime.Now);
        }

        public static int ElapsedYears(this DateTime originalDate, DateTime currentDate)
        {
            var years = currentDate.Year - originalDate.Year;
            if (currentDate.Month == originalDate.Month && currentDate.Day < originalDate.Day
                || currentDate.Month < originalDate.Month)
                return --years;
            return years;
        }
    }
}