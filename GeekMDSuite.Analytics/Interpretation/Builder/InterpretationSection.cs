using System;
using System.Collections.Generic;
using System.Linq;

namespace GeekMDSuite.Analytics.Interpretation.Builder
{
    public class InterpretationSection 
    {
        public string Title { get; set; }
        public List<string> Paragraphs { get; set; }

        public static InterpretationSection Build(string title, List<string> paragraphs) =>
                new InterpretationSection(title, paragraphs);
        
        private InterpretationSection(string title, List<string> paragraphs)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentOutOfRangeException($"{nameof(title)} should not be empty.");
            Title = title;
            
            Paragraphs = paragraphs ?? throw new ArgumentNullException(nameof(paragraphs));
            if (!Paragraphs.Any())
                throw new ArgumentException("There must be at least one paragraph");
        }

        internal InterpretationSection()
        {
            
        }
    }
}