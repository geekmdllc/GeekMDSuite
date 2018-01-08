using System;
using GeekMDSuite.Utilities.Extensions;

namespace GeekMDSuite.Core.Models
{
    public class Name
    {
        public Name()
        {
        }

        private Name(string first, string last, string middle = "")
        {
            First = first;
            Middle = middle;
            Last = last;

            if (IsMalformed)
                throw new ArgumentOutOfRangeException(
                    $"{nameof(first)} and {nameof(last)} cannot be empty or white space.");
        }

        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }

        public bool IsMalformed => First.IsEmpty() || Last.IsEmpty();

        public static Name Build(string first, string last, string middle = "")
        {
            return new Name(first, last, middle);
        }

        public override string ToString()
        {
            return string.Format($"{First}{(string.IsNullOrEmpty(Middle) ? "" : $" {Middle}")} {Last}");
        }

        public bool IsSimilarTo(string comparison)
        {
            return ToString().HasStringsInCommonWith(comparison);
        }

        public bool IsSimilarTo(Name comparison)
        {
            return ToString().HasStringsInCommonWith(comparison.ToString());
        }

        public bool IsSameAs(string comparison)
        {
            return ToString().IsEqualTo(comparison);
        }
    }
}