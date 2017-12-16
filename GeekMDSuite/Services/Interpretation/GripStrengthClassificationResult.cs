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

        public GripStrengthClassification Left { get; private set; }
        public GripStrengthClassification Right { get; private set; }

        public GripStrengthClassification WorseSide => LeftWorseThanRight() ? Left : Right;
        public Laterality Laterality => LeftWorseThanRight() ? Laterality.Left : Laterality.Right;

        private bool LeftWorseThanRight() => _mapToValue[Left] > _mapToValue[Right];

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
    }
}