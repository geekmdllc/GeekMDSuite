using System;
using GeekMDSuite.Utilities.Extensions;
using Xunit;

namespace GeekMDSuite.Utilities.UnitTests
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void ElapsedYears_Given100YearsMinusOneDay_Returns99()
        {
            var dob = new DateTime(1900, 1, 1);
            var currentDate = new DateTime(1999, 12, 31);

            var age = dob.ElapsedYears(currentDate);
            Assert.Equal(99, age);
        }

        [Fact]
        public void ElapsedYears_Given100YearsPlusOneDay_Returns100()
        {
            var dob = new DateTime(1900, 1, 1);
            var currentDate = new DateTime(2000, 1, 2);

            var age = dob.ElapsedYears(currentDate);
            Assert.Equal(100, age);
        }

        [Fact]
        public void ElapsedYears_GivenExactly100YearTime_Returns100()
        {
            var dob = new DateTime(1900, 1, 1);
            var currentDate = new DateTime(2000, 1, 1);

            var age = dob.ElapsedYears(currentDate);
            Assert.Equal(100, age);
        }
    }
}