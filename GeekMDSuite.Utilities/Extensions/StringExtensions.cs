using System;
using System.Linq;

namespace GeekMDSuite.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static bool DoesNotContain(this string self, string comparison) => !self.Contains(comparison);
        
        public static bool IsNotNullOrEmpty(this string self) => !IsEmpty(self);

        public static bool IsEmpty(this string self) => string.IsNullOrWhiteSpace(self);

        public static bool HasStringsInCommonWith(this string self, string comparison)
        {
            var selfStringList = self.ToLower().Replace(",", string.Empty).Split();
            var comparisonStringList = comparison.ToLower().Replace(",", string.Empty).Split();
            var discoverd = false;

            foreach (var comparisonString in comparisonStringList)
                if (selfStringList.Any(selfString => selfString.Contains(comparisonString)))
                    discoverd = true;

            return discoverd;
        }

        public static bool DoesNotHaveStringsInCommonWith(this string self, string comparison)
        {
            return !HasStringsInCommonWith(self, comparison);
        }

        public static bool IsEqualTo(this string self, string comparison)
        {
            return string.Equals(self, comparison, StringComparison.OrdinalIgnoreCase);
        }

        public static string SplitAtCapitalization(this string self)
        {
            var i = 0;
            var newString = string.Empty;
            foreach (var c in self) newString += $"{(char.IsUpper(c) && i++ > 0 ? $" {c}" : $"{c}")}";

            return newString;
        }
    }
}