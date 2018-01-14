using System;
using GeekMDSuite.Utilities.Extensions;

namespace GeekMDSuite.Core.Models
{
    public class Name
    {
        public Name()
        {
        }

        private Name(string first, string last, string middle = "") : this()
        {
            First = first;
            Middle = middle;
            Last = last;

            if (IsMissingFirstOrLast())
                throw new ArgumentOutOfRangeException(
                    $"{nameof(first)} and {nameof(last)} cannot be empty or white space.");
        }

        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }

        public static Name Build(string first, string last, string middle = "")
        {
            return new Name(first, last, middle);
        }

        public bool IsMissingFirstOrLast()
        {
            return First.IsEmpty() || Last.IsEmpty();
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

        public override string ToString()
        {
            return $"{First}{(string.IsNullOrEmpty(Middle) ? "" : $" {Middle}")} {Last}";
        }
    }
}