using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Utilities.Extensions
{
    public static class NameHelpers
    {
        public static bool IsSimilarTo(this Name name, string comparison)
        {
            return name.ToString().HasStringsInCommonWith(comparison);
        }

        public static bool IsSimilarTo(this Name name, Name comparison)
        {
            return name.ToString().HasStringsInCommonWith(comparison.ToString());
        }

        public static bool IsSameAs(this Name name, string comparison)
        {
            return name.ToString().IsEqualTo(comparison);
        }

        public static bool IsMalformed(this Name name)
        {
            return name.First.IsEmpty() || name.Last.IsEmpty();
        }
    }
}