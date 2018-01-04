using System;
using System.Linq;
using GeekMDSuite.Analytics.Interpretation.Builder;
using Xunit;

namespace GeekMDSuite.Analytics.UnitTests.Interpretation
{
    public class InterpretationSectionBuilderTests
    {

        [Fact]
        public void GivenEmptyTitle_ThrowsMissingMethodException()
        {
            var section = new InterpretationSectionBuilder()
                .SetTitle(string.Empty)
                .AddParagraph(string.Empty);

            Assert.Throws<MissingMethodException>(() => section.Build());
        }
        
        [Fact]
        public void GivenNoParagraphs_ThrowsMissingMethodException()
        {
            var section = new InterpretationSectionBuilder()
                .SetTitle(string.Empty);

            Assert.Throws<MissingMethodException>(() => section.Build());
        }

        [Fact]
        public void BuildWithoutPreBuildValidation_GivenEmptyTitle_Succeeds()
        {
            var section = InterpretationSectionBuilder.Initialize()
                .SetTitle(string.Empty)
                .AddParagraph("Paragraph")
                .BuildWithoutModelValidation();

            Assert.IsType<InterpretationSection>(section);
        }
        
        [Fact]
        public void BuildWithoutPreBuildValidation_GivenNoParagraphs_Succeeds()
        {
            var section = InterpretationSectionBuilder.Initialize()
                .SetTitle("Title")
                .BuildWithoutModelValidation();

            Assert.IsType<InterpretationSection>(section);
        }
        
        [Fact]
        public void BuildWithoutPreBuildValidation_GivenNoTitleOrParagraphs_Succeeds()
        {
            var section = InterpretationSectionBuilder.Initialize()
                .BuildWithoutModelValidation();

            Assert.IsType<InterpretationSection>(section);
        }
        
        [Fact]
        public void InterpreationSectionWithFourSections_ReturnsParagraphsInOrder()
        {
            var section = new InterpretationSectionBuilder()
                .SetTitle("Title")
                .AddParagraph("one")
                .AddParagraph("two")
                .AddParagraph("three")
                .AddParagraph("four")
                .Build();

            var paragraphOfInterest = section.Paragraphs.Where(p => p.Contains("four"));
                

            Assert.True(paragraphOfInterest.Any());
            Assert.Equal(4, section.Paragraphs.Count);
        }

        [Fact]
        public void InterpretationSectionWithThreeParagraphs_ReturnsParagraphsInOrder()
        {          
            var section = new InterpretationSectionBuilder()
                .SetTitle("Title")
                .AddParagraph("one")
                .AddParagraph("two")
                .AddParagraph("three")
                .Build();

            var paragraphOfInterest = section.Paragraphs.Where(p => p.Contains("three"));
                

            Assert.True(paragraphOfInterest.Any());
            Assert.Equal(3, section.Paragraphs.Count);
        }
    }
}