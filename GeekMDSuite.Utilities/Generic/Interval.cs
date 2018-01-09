using System;

namespace GeekMDSuite.Utilities.Generic
{
    public class Interval<T> where T : struct, IComparable
    {
        public Interval(T lower, T upper)
        {
            Upper = upper;
            Lower = lower;
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public T Upper { get; }
        public T Lower { get; }

        public static Interval<T> Create(T lower, T upper)
        {
            return new Interval<T>(lower, upper);
        }

        public bool ContainsClosed(T val)
        {
            return GreaterThanOrEqualToLowerBound(val) && LowerThanOrEqualToUpperBound(val);
        }

        public bool ContainsOpen(T val)
        {
            return GreaterThanLowerBound(val) && LessThanUpperBound(val);
        }

        public bool ContainsRightOpen(T val)
        {
            return GreaterThanOrEqualToLowerBound(val) && LessThanUpperBound(val);
        }

        public bool ContainsLeftOpen(T val)
        {
            return GreaterThanLowerBound(val) && LowerThanOrEqualToUpperBound(val);
        }

        private bool GreaterThanOrEqualToLowerBound(T val)
        {
            return Lower.CompareTo(val) <= 0;
        }

        private bool LowerThanOrEqualToUpperBound(T val)
        {
            return Upper.CompareTo(val) >= 0;
        }

        private bool GreaterThanLowerBound(T val)
        {
            return Lower.CompareTo(val) < 0;
        }

        private bool LessThanUpperBound(T val)
        {
            return Upper.CompareTo(val) > 0;
        }
    }
}