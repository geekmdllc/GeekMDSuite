﻿using System;

namespace GeekMDSuite.Tools.Generic
{
    public class Interval<T> where T : struct, IComparable
    {
        public Interval(T lower, T upper)
        {
            Upper = upper;
            Lower = lower;
        }

        private T Upper { get; }
        private T Lower { get; }
        
        public bool ContainsClosed(T val) => ( GreaterThanOrEqualToLowerBound(val) && LowerThanOrEqualToUpperBound(val) );
        public bool ContainsOpen(T val) => ( GreaterThanLowerBound(val) && LessThanUpperBound(val) );
        public bool ContainsRightOpen(T val) => ( GreaterThanOrEqualToLowerBound(val) && LessThanUpperBound(val) );
        public bool ContainsLeftOpen(T val) => ( GreaterThanLowerBound(val) && LowerThanOrEqualToUpperBound(val) );
        
        private bool GreaterThanOrEqualToLowerBound(T val) => Lower.CompareTo(val) <= 0;
        private bool LowerThanOrEqualToUpperBound(T val) => Upper.CompareTo(val) >= 0;
        private bool GreaterThanLowerBound(T val) => Lower.CompareTo(val) < 0;
        private bool LessThanUpperBound(T val) => Upper.CompareTo(val) > 0;
    }
}