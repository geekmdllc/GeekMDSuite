using GeekMDSuite.Analytics.Interpretation;
using GeekMDSuite.Analytics.Interpretation.Builder;
using GeekMDSuite.Core;
using GeekMDSuite.Core.Models;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Interpretation
{
    public class InterpretableTests
    {
        [Theory]
        [InlineData("fake blood pressure")]
        [InlineData("fake summary where your blood pressure is")]
        [InlineData("section1 title")]
        [InlineData("section 1 paragraph 1")]
        [InlineData("section 1 paragraph 2")]
        [InlineData("section2 title")]
        [InlineData("section 2 paragraph 1")]
        [InlineData("section 2 paragraph 2")]
        [InlineData("70")]
        [InlineData("95", 95)]
        [InlineData("115", 115)]
        [InlineData("125", 125)]
        [InlineData("135", 135)]
        [InlineData("145", 145)]
        [InlineData("165", 165)]
        [InlineData("185", 185)]
        [InlineData("185", 185, 120, true)]
        public void ToString_ContainsAllElementsOfInterpretationText(string element, int systolic = 0, 
        int diastolic = 70, bool organDamage = false)
        {
            var fakeInterp = new FakeBloodPressureInterpretation(
                BloodPressure.Build(systolic, diastolic, organDamage));
            
            Assert.Contains(element.ToLower(), fakeInterp.ToString().ToLower());
        }
        
        private class FakeBloodPressureInterpretation : Interpretable
        {
            private BloodPressure _bp;

            public FakeBloodPressureInterpretation(BloodPressure bp)
            {
                _bp = bp;
            }

            public override InterpretationText Interpretation => InterpretationTextBuilder.Initialize()
                .SetTitle("Fake Blood Pressure")
                .SetSummary($"Fake summary where your blood pressure is {_bp.Systolic} / {_bp.Diastolic} mmHg.")
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