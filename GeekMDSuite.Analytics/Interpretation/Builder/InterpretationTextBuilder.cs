using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeekMDSuite.Core.Builders;

namespace GeekMDSuite.Analytics.Interpretation.Builder
{
    public class InterpretationTextBuilder : Builder<InterpretationTextBuilder, InterpretationText>
    {
        private readonly List<InterpretationSection> _sections = new List<InterpretationSection>();
        private string _summary;


        private string _title;

        public override InterpretationText BuildWithoutModelValidation()
        {
            return new InterpretationText
            {
                Sections = _sections,
                Summary = _summary,
                Title = _title
            };
        }

        public override InterpretationText Build()
        {
            ValidatePreBuildState();
            return BuildWithoutModelValidation();
        }

        public InterpretationTextBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public InterpretationTextBuilder SetSummary(string summary)
        {
            _summary = summary;
            return this;
        }

        public InterpretationTextBuilder AddSection(InterpretationSection section)
        {
            _sections.Add(section);
            return this;
        }

        private void ValidatePreBuildState()
        {
            var messageBuilder = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_title))
                messageBuilder.Append($"{nameof(SetTitle)}");
            if (!_sections.Any() && string.IsNullOrWhiteSpace(_summary))
                messageBuilder.Append(
                    $"At least {nameof(SetSummary)} or {nameof(AddSection)} must be called at least once");

            var message = messageBuilder.ToString();
            if (!string.IsNullOrEmpty(message))
                throw new MissingMethodException(message);
        }
    }
}