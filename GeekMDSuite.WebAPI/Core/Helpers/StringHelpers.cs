using System;

namespace GeekMDSuite.WebAPI.Core.Helpers
{
    internal static class StringHelpers
    {
        internal static bool HasStringsInCommonWith(this string query, string comparison)
        {
            var queryStringList = query.ToLower().Replace(",", "").Split();
            var comparisonString = comparison.ToLower();
            var discoverd = false;
            
            foreach (var queryString in queryStringList) discoverd = comparisonString.Contains(queryString);

            return discoverd;
        }
        
        internal static bool IsEqualTo(this string query, string comparison) 
            => string.Equals(query, comparison, StringComparison.OrdinalIgnoreCase);
    }
}