using System;

namespace GeekMDSuite.Utilities.Extensions
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

        public static bool IsOutOfRange(this DateTime date)
        {
            return date <= DateTime.Now.AddYears(-150) || date >= DateTime.Now;
        }
    }
}