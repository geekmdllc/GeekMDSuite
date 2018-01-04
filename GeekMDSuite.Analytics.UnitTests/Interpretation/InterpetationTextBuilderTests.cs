using System;
using GeekMDSuite.Analytics.Interpretation;
using GeekMDSuite.Analytics.Interpretation.Builder;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Interpretation
{
    public class InterpetationTextBuilderTests
    {
        [Fact]
        public void Build_WithoutTitle_ThrowsMissingMethodException()
        {
             var builder = InterpretationTextBuilder.Initialize()
                 .SetSummary("Summary")
                 .AddSection( InterpretationSectionBuilder.Initialize().BuildWithoutModelValidation());

            Assert.Throws<MissingMethodException>(() => builder.Build());

        }
        
        [Fact]
        public void Build_WithoutSummaryAndSection_ThrowsMissingMethodException()
        {
            var builder = InterpretationTextBuilder.Initialize()
                .SetTitle("Tite");

            Assert.Throws<MissingMethodException>(() => builder.Build());

        }
        
        [Fact]
        public void Build_WithTitleAndSummary_Suceeds()
        {
            var builder = InterpretationTextBuilder.Initialize()
                .SetTitle("Tite")
                .SetSummary("Summary");

            var text = builder.Build();

            Assert.IsType<InterpretationText>(text);
        }
        
        [Fact]
        public void Build_WithTitleAndSection_Suceeds()
        {
            var builder = InterpretationTextBuilder.Initialize()
                .SetTitle("Tite")
                .AddSection(InterpretationSectionBuilder.Initialize()
                    .AddParagraph("Paragraph")
                    .BuildWithoutModelValidation());

            var text = builder.Build();

            Assert.IsType<InterpretationText>(text);
        }
    }
}