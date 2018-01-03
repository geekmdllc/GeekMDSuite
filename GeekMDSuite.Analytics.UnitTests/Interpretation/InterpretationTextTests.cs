using System;
using System.Collections.Generic;
using GeekMDSuite.Analytics.Interpretation;
using GeekMDSuite.Analytics.Interpretation.Builder;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Interpretation
{
    public class InterpretationTextTests
    {
        [Fact]
        public void GivenNullOrEmptySection_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new InterpretationText("Title", string.Empty, null));
        }
        
        [Fact]
        public void GivenNullOrEmptyTitle_ThrowsArgumentOutOfRangeException()
        {
            var section = new InterpretationSectionBuilder()
                .SetTitle(string.Empty)
                .AddParagraph(string.Empty)
                .Build();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new InterpretationText(string.Empty, string.Empty, new List<InterpretationSection> {section}));
        }
        
        
        [Fact]
        public void ToString_ContainsTitle()
        {
            var section = new InterpretationSectionBuilder()
                .AddParagraph(string.Empty)
                .SetTitle(string.Empty)
                .Build();

            var interp = new InterpretationBuilder()
                .SetTitle("Title")
                .SetSummary(string.Empty)
                .AddSection(section)
                .Build();
            
            Assert.Contains("Title", interp.Title);
        }
    }
}