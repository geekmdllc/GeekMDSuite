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
                InterpretationText.Build("Title", string.Empty, null));
        }

        [Fact]
        public void GivenNullOrEmptyTitle_ThrowsArgumentOutOfRangeException()
        {
            var section = InterpretationSectionBuilder.Initialize()
                .SetTitle(string.Empty)
                .AddParagraph(string.Empty)
                .BuildWithoutModelValidation();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                InterpretationText.Build(string.Empty, string.Empty, new List<InterpretationSection> {section}));
        }

        [Fact]
        public void ToString_ContainsTitle()
        {
            var section = InterpretationSectionBuilder.Initialize()
                .AddParagraph(string.Empty)
                .SetTitle(string.Empty)
                .BuildWithoutModelValidation();

            var interp = new InterpretationTextBuilder()
                .SetTitle("Title")
                .SetSummary(string.Empty)
                .AddSection(section)
                .Build();

            Assert.Contains("Title", interp.ToString());
        }
    }
}