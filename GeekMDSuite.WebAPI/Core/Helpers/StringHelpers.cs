using System;

namespace GeekMDSuite.WebAPI.Core.Helpers
{
    public static class StringHelpers
    {
        public static bool HasStringsInCommonWith(this string query, string comparison)
        {
            var queryStringList = query.ToLower().Replace(",", "").Split();
            var comparisonString = comparison.ToLower();
            var discoverd = false;
            
            foreach (var queryString in queryStringList) discoverd = comparisonString.Contains(queryString);

            return discoverd;
        }
        
        public static bool IsEqualTo(this string query, string comparison) 
            => string.Equals(query, comparison, StringComparison.OrdinalIgnoreCase);
    }
}