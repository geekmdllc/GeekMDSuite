﻿using System;

namespace GeekMDSuite.WebAPI.Core.Helpers
{
    public static class DateTimeHelpers
    {
        public static bool IsOutOfRange(this DateTime date)
        {
            return date <= DateTime.Now.AddYears(-150) || date >= DateTime.Now;
        }
    }
}