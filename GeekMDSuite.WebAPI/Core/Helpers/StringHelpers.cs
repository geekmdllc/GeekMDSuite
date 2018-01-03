using System;
using System.Linq;

namespace GeekMDSuite.WebAPI.Core.Helpers
{
    public static class StringHelpers
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
        
        public static bool IsEqualTo(this string query, string comparison) 
            => string.Equals(query, comparison, StringComparison.OrdinalIgnoreCase);
    }
}