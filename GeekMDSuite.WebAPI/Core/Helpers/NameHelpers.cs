using GeekMDSuite.Core;

namespace GeekMDSuite.WebAPI.Core.Helpers
{
    public static class NameHelpers
    {
        public static bool IsSimilarTo(this Name name, string comparison)
        {
            return name.ToString().HasStringsInCommonWith(comparison);
        }
        
        public static bool IsSimilarTo(this Name name, Name comparison) => name.ToString().HasStringsInCommonWith(comparison.ToString());

        public static bool IsSameAs(this Name name, string comparison) => name.ToString().IsEqualTo(comparison);

        public static bool IsMalformed(this Name name) => name.First.IsEmpty() || name.Last.IsEmpty();
    }
}