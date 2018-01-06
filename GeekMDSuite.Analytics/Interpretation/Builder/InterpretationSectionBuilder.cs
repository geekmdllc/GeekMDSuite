using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeekMDSuite.Core.Builders;

namespace GeekMDSuite.Analytics.Interpretation.Builder
{
    public class InterpretationSectionBuilder : Builder<InterpretationSectionBuilder, InterpretationSection>
    {
        private readonly List<string> _paragraphs;

        private string _title;

        public InterpretationSectionBuilder()
        {
            _paragraphs = new List<string>();
        }

        public override InterpretationSection Build()
        {
            ValidatePreBuildState();
            return BuildWithoutModelValidation();
        }

        public override InterpretationSection BuildWithoutModelValidation()
        {
            return new InterpretationSection
            {
                Paragraphs = _paragraphs,
                Title = _title
            };
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

        private void ValidatePreBuildState()
        {
            var messageBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_title))
                messageBuilder.Append($"{nameof(SetTitle)} must recieve a title.");
            if (!_paragraphs.Any())
                messageBuilder.Append($"{nameof(AddParagraph)} must receive at least on paragraph.");

            var message = messageBuilder.ToString();
            if (!string.IsNullOrEmpty(message))
                throw new MissingMethodException(message);
        }
    }
}