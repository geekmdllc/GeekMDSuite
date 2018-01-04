using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeekMDSuite.Analytics.Interpretation.Builder;

namespace GeekMDSuite.Analytics.Interpretation
{
    public class InterpretationText
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public List<InterpretationSection> Sections { get; set; }

        internal InterpretationText()
        {
            Sections = new List<InterpretationSection>();
        }

        public static InterpretationText Build(string title, string summary, List<InterpretationSection> sections)
        {
            return new InterpretationText(title, summary, sections);
        }

        public override string ToString()
        {
            var spacer = Environment.NewLine + Environment.NewLine;
            var stringBuilder = new StringBuilder();
            stringBuilder
                .Append(Title).Append(spacer)
                .Append(string.IsNullOrWhiteSpace(Summary) ? string.Empty : Summary + spacer)
                .Append(GetSectionsText(Sections));
            
            return stringBuilder.ToString();
        }

        private InterpretationText(string title, string summary, List<InterpretationSection> sections)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentOutOfRangeException(nameof(title));

            Title = title; 
            Summary = summary;
            Sections = sections ?? throw new ArgumentNullException(nameof(sections));
        }

        private static string GetSectionsText(IEnumerable<InterpretationSection> sections)
        {
            return sections.Aggregate(string.Empty, (current, section) 
                => current + section.Title + Environment.NewLine + Environment.NewLine + GetParagraphsText(section));
        }

        private static string GetParagraphsText(InterpretationSection section)
        {
            return section.Paragraphs.Aggregate(string.Empty, (current, parapraph) 
                => current + parapraph + Environment.NewLine + Environment.NewLine);
        }
    }
}