using GeekMDSuite.Core.Tools.Generic;
using Xunit;

namespace GeekMDSuite.Core.UnitTests
{
    public class IntervalTests
    {
        [Fact]
        public void ContainsClosed_IncludesEdgeCases()
        {
            var interval = new Interval<int>(1, 10);
            Assert.True(interval.ContainsClosed(1));
            Assert.True(interval.ContainsClosed(10));
        }
        
        [Fact]
        public void ContainsOpen_ExcludesEdgeCases()
        {
            var interval = new Interval<int>(1, 10);
            Assert.False(interval.ContainsOpen(1));
            Assert.False(interval.ContainsOpen(10));
        }
        
        [Fact]
        public void ContainsLeftOpen_ExcludesLeftEdgeCaseIncludesRightEdgeCase()
        {
            var interval = new Interval<int>(1, 10);
            Assert.False(interval.ContainsLeftOpen(1));
            Assert.True(interval.ContainsLeftOpen(10));
        }
        
        [Fact]
        public void ContainsRightOpen_IncludesLeftEdgeCaseExcludesRightEdgeCases()
        {
            var interval = new Interval<int>(1, 10);
            Assert.True(interval.ContainsRightOpen(1));
            Assert.False(interval.ContainsRightOpen(10));
        }
    }
}