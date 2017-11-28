using System.Collections.Generic;

namespace GeekMDSuite
{
    public class InterpretationBuilder
    {
        private string _title;
        private string _summary;
        private readonly List<InterpretationSection> _sections = new List<InterpretationSection>();

        public InterpretationBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public InterpretationBuilder SetSummary(string summary)
        {
            _summary = summary;
            return this;
        }

        public InterpretationBuilder AddSection(InterpretationSection section)
        {
            _sections.Add(section);
            return this;
        }

        public Interpretation Build()
        {
            return new Interpretation(_title, _summary, _sections);
        }
        
    }
}