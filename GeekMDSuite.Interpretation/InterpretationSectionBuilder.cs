using System.Collections.Generic;

namespace GeekMDSuite.Interpretation
{
    public class InterpretationSectionBuilder
    {
        private string _title;
        private readonly List<string> _paragraphs;

        public InterpretationSectionBuilder()
        {
            _paragraphs = new List<string>();
        }

        public InterpretationSectionBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }
        
        public InterpretationSectionBuilder AddParagraph(string paragraph)
        {
            _paragraphs.Add(paragraph);
            return this;
        }

        public InterpretationSection Build()
        {
            return new InterpretationSection(_title, _paragraphs);
        }
    }
}