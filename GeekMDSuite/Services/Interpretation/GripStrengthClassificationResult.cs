using System.Collections.Generic;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class GripStrengthClassificationResult
    {
        private GripStrengthClassificationResult(GripStrengthClassification left, GripStrengthClassification right)
        {
            Left = left;
            Right = right;
        }

        public GripStrengthClassification Left { get; }
        public GripStrengthClassification Right { get; }

        public GripStrengthClassification WorseSide => LeftWorseThanRight() ? Left : Right;
        public Laterality Laterality => LeftWorseThanRight() ? Laterality.Left : Laterality.Right;

        private bool LeftWorseThanRight() => _mapToValue[Left] < _mapToValue[Right];

        private readonly Dictionary<GripStrengthClassification, int> _mapToValue = new Dictionary<GripStrengthClassification, int>()
        {
            {GripStrengthClassification.Weak, 0},
            {GripStrengthClassification.Normal, 1},
            {GripStrengthClassification.Strong, 2}
        };
        
        public static GripStrengthClassificationResult Create(GripStrengthClassification left, GripStrengthClassification right)
        {
            return new GripStrengthClassificationResult(left, right);
        }

        public override string ToString() => 
            $"The worse side is on the {Laterality}, the left strength was {Left}, the right side was {Right}.";
    }
}