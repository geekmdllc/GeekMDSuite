using System;
using System.Collections.Generic;
using GeekMDSuite.Analytics.Interpretation.Builder;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Interpretation
{
    public class InterpretationSectionTests
    {
        [Fact]
        public void Build_GivenEmptyTitle_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => InterpretationSection.Build(string.Empty, new List<string>{ "Paragraph 1"}));
        }
        
        [Fact]
        public void Build_GivenWhitespaceTitle_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => InterpretationSection.Build(" ", new List<string>{ "Paragraph 1"}));
        }
        
        [Fact]
        public void Build_GivenEmptyParagraphsList_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentException>(
                () => InterpretationSection.Build("Title", new List<string>( )));
        }
        
        [Fact]
        public void Build_GivenNullParagraphsList_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => InterpretationSection.Build("Title", null));
        }
    }
}