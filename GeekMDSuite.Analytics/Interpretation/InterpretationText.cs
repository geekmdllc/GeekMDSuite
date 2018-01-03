using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeekMDSuite.Analytics.Interpretation.Builder;

namespace GeekMDSuite.Analytics.Interpretation
{
    public class InterpretationText
    {
        public string Title { get; }
        public string Summary { get; }
        public List<InterpretationSection> Sections { get; }

        public InterpretationText(string title, string summary, List<InterpretationSection> sections)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentOutOfRangeException("A title must be given.");

            Title = title; 
            Summary = summary;
            Sections = sections ?? throw new ArgumentNullException(nameof(sections));
        }

        public override string ToString()
        {
            var spacer = Environment.NewLine + Environment.NewLine;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Title)
                .Append(spacer)
                .Append(string.IsNullOrWhiteSpace(Summary) ? string.Empty : Summary + spacer)
                .Append(GetSectionsText(Sections));
            
            return stringBuilder.ToString();
        }

        private static string GetSectionsText(IEnumerable<InterpretationSection> sections)
        {
            return sections.Aggregate(string.Empty, (current, section) => current + $"{section.Title}\n\n{GetParagraphsText(section)}");
        }

        private static string GetParagraphsText(InterpretationSection section)
        {
            return section.Paragraphs.Aggregate(string.Empty, (current, parapraph) => $"{current}{parapraph}\n\n");
        }
    }
}