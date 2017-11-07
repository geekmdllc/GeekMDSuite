using System;

namespace GeekMDSuite.Common.Tools
{
    public class Interval<T> where T : struct, IComparable
    {
        // TODO: The uppoer and lower are reversed.
        public Interval(T lower, T upper)
        {
            Upper = upper;
            Lower = lower;
        }

        private T Upper { get; }
        private T Lower { get; }
        
        public bool ContainsClosed(T z) => ( Lower.CompareTo(z) <= 0 && Upper.CompareTo(z) >= 0 );
        public bool ContainsOpen(T z) => ( Lower.CompareTo(z) < 0 && Upper.CompareTo(z) > 0 );
        public bool ContainsRightOpen(T z) => ( Lower.CompareTo(z) <= 0 && Upper.CompareTo(z) > 0 );
        public bool ContainsLeftOpen(T z) => ( Lower.CompareTo(z) < 0 && Upper.CompareTo(z) >= 0 );
    }
}