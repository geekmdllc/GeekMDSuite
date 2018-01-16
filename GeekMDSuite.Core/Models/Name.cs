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

        public bool IsMissingFirstOrLast() => First.IsEmpty() || Last.IsEmpty();

        public bool IsSimilarTo(string comparison) => ToString().HasStringsInCommonWith(comparison);

        public bool IsNotSimilarTo(string comparison) => !IsSimilarTo(comparison);

        public bool IsSimilarTo(Name comparison) => ToString().HasStringsInCommonWith(comparison.ToString());

        public bool IsNotSimilarTo(Name comparison) => !IsSimilarTo(comparison);

        public bool IsSameAs(string comparison) => ToString().IsEqualTo(comparison);

        public bool IsNotSameAs(string comparison) => !IsSameAs(comparison);

        public override string ToString()
        {
            return $"{First}{(string.IsNullOrEmpty(Middle) ? "" : $" {Middle}")} {Last}";
        }
    }
}