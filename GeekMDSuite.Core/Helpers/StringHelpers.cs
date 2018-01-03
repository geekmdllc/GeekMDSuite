namespace GeekMDSuite.Core.Helpers
{
    public static class StringHelpers
    {
        public static string SplitAtCapitalization(this string str)
        {
            var i = 0;
            var newString = string.Empty;
            foreach (var c in str)
            {
                newString += $"{(char.IsUpper(c) && i++ > 0 ? $" {c}" : $"{c}")}";
            }

            return newString;
        }
    }
}