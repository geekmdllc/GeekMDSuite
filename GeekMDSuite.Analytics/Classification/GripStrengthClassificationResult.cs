using System.Collections.Generic;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class GripStrengthClassificationResult
    {
        private GripStrengthClassificationResult(GripStrengthScore left, GripStrengthScore right)
        {
            Left = left;
            Right = right;
        }

        public GripStrengthScore Left { get; }
        public GripStrengthScore Right { get; }

        public GripStrengthScore WorseSide => LeftWorseThanRight() ? Left : Right;
        public Laterality Laterality => LeftWorseThanRight() ? Laterality.Left : Laterality.Right;

        
        public static GripStrengthClassificationResult Create(GripStrengthScore left, GripStrengthScore right)
        {
            return new GripStrengthClassificationResult(left, right);
        }

        public override string ToString() => 
            $"The worse side is on the {Laterality}, the left strength was {Left}, the right side was {Right}.";
        
        private bool LeftWorseThanRight() => _mapToValue[Left] < _mapToValue[Right];

        private readonly Dictionary<GripStrengthScore, int> _mapToValue = new Dictionary<GripStrengthScore, int>()
        {
            {GripStrengthScore.Weak, 0},
            {GripStrengthScore.Normal, 1},
            {GripStrengthScore.Strong, 2}
        };
    }
}