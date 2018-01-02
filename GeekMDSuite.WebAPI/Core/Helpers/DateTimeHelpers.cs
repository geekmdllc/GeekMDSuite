﻿using System;

namespace GeekMDSuite.WebAPI.Core.Helpers
{
    public static class DateTimeHelpers
    {
        public static bool IsInvalidAge(this DateTime date) => date <= DateTime.Now.AddYears(-150) || date >= DateTime.Now;
    }
}