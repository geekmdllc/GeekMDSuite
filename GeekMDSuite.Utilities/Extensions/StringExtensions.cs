using System;
using System.Linq;

namespace GeekMDSuite.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string query) => string.IsNullOrWhiteSpace(query);

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

        public static bool IsEqualTo(this string query, string comparison) => 
            string.Equals(query, comparison, StringComparison.OrdinalIgnoreCase);

        public static string SplitAtCapitalization(this string str)
        {
            var i = 0;
            var newString = string.Empty;
            foreach (var c in str) newString += $"{(char.IsUpper(c) && i++ > 0 ? $" {c}" : $"{c}")}";

            return newString;
        }
    }
}