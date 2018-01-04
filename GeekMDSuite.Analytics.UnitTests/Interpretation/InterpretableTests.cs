using GeekMDSuite.Analytics.Interpretation;
using GeekMDSuite.Analytics.Interpretation.Builder;
using GeekMDSuite.Core;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Interpretation
{
    public class InterpretableTests
    {
        [Theory]
        [InlineData("fake blood pressure")]
        [InlineData("fake summary.")]
        [InlineData("section1 title")]
        [InlineData("section 1 paragraph 1")]
        [InlineData("section 1 paragraph 2")]
        [InlineData("section2 title")]
        [InlineData("section 2 paragraph 1")]
        [InlineData("section 2 paragraph 2")]
        public void ToString_ContainsAllElementsOfInterpretationText(string element)
        {
            Assert.Contains(element.ToLower(), FakeInterp.ToString().ToLower());
        }

        
        private FakeBloodPressureInterpretation FakeInterp =>
            new FakeBloodPressureInterpretation(BloodPressure.Build(175, 95));
        
        private class FakeBloodPressureInterpretation : Interpretable
        {
            private BloodPressure _bloodPressure;

            public FakeBloodPressureInterpretation(BloodPressure bloodPressure)
            {
                _bloodPressure = bloodPressure;
            }

            public override InterpretationText Interpretation => InterpretationTextBuilder.Initialize()
                .SetTitle("Fake Blood Pressure")
                .SetSummary("Fake summary.")
                .AddSection(Section1())
                .AddSection(Section2())
                .Build();

            private InterpretationSection Section1() => InterpretationSectionBuilder.Initialize()
                .SetTitle("Section1 Title")
                .AddParagraph("Section 1 Paragraph 1")
                .AddParagraph("Section 1 Paragraph 2")
                .Build();

            private InterpretationSection Section2() => InterpretationSectionBuilder.Initialize()
                .SetTitle("Section2 Title")
                .AddParagraph("Section 2 Paragraph 1")
                .AddParagraph("Section 2 Paragraph 2")
                .Build();
        }
    }
}