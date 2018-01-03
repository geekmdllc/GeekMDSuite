using System.Linq;
using GeekMDSuite.Analytics.Interpretation;
using GeekMDSuite.Analytics.Interpretation.Builder;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Interpretation
{
    public class InterpretationSectionTests
    {
        [Fact]
        public void InterpretationSectionBuilder_InterpreationSectionWithFourSections_ReturnsParagraphsInOrder()
        {
            var stringFound = BuildInterpretation(BuildSection1(), BuildSection2())
                .Sections
                .ElementAt(IndexFromPosition(1))?
                .Paragraphs
                .ElementAt(IndexFromPosition(4))
                .ToLower()
                .Contains("fourth");

            Assert.True(stringFound);
        }

        [Fact]
        public void InterpretationSectionBuilder_InterpretationSectionWithThreeParagraphs_ReturnsParagraphsInOrder()
        {          
            var stringFound = BuildInterpretation(BuildSection1(), BuildSection2())
                .Sections
                .ElementAt(IndexFromPosition(2))?
                .Paragraphs
                .ElementAt(IndexFromPosition(3))
                .ToLower()
                .Contains("third");
            
            Assert.True(stringFound);
        }

        private static int IndexFromPosition(int position) => position > 0 ? position - 1 : 0;
        
        private static InterpretationText BuildInterpretation(InterpretationSection section1, InterpretationSection section2)
        {
            var interp = new InterpretationBuilder()
                .SetTitle("Classification Title")
                .SetSummary("Summary of interpretation")
                .AddSection(section1)
                .AddSection(section2)
                .Build();
            return interp;
        }

        private static InterpretationSection BuildSection2()
        {
            var section2 = new InterpretationSectionBuilder()
                .SetTitle("Second Section Title")
                .AddParagraph("First paragraph of the second section.")
                .AddParagraph("Second paragraph of the second section.")
                .AddParagraph("Third paragraph of the second section.")
                .Build();
            return section2;
        }

        private static InterpretationSection BuildSection1()
        {
            var section1 = new InterpretationSectionBuilder()
                .SetTitle("First Section Title")
                .AddParagraph("First paragraph of the first section.")
                .AddParagraph("Second paragraph of the first section.")
                .AddParagraph("Third paragraph of the first section.")
                .AddParagraph("Fourth paragraph of the first section.")
                .Build();
            return section1;
        }
    }
}