using System.Collections.Generic;
using System.Linq;

namespace GeekMDSuite.Interpretation
{
    public class Interpretation
    {
        public string Title { get; }
        public string Summary { get; }
        public List<InterpretationSection> Sections { get; }

        public Interpretation(string title, string summary, List<InterpretationSection> sections)
        {
            Title = title;
            Summary = summary;
            Sections = sections;
        }

        public override string ToString()
        {
            return $"{Title}\n\n" +
                   $"{Summary}\n\n" +
                   $"{BuildSections()}";
        }

        private string BuildSections()
        {
            var sections = "";
            foreach (var section in Sections)
            {
                var result = BuildSectionParagraphs(section);
                sections += section.Title + "\n\n" + result;
            }
            return sections;
        }

        private static string BuildSectionParagraphs(InterpretationSection section)
        {
            var result = "";
            foreach (var parapraph in section.Paragraphs)
                result = result + parapraph + "\n\n";
            return result;
        }
    }
}