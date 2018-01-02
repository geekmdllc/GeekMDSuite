using System;
using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Core.Analytics.Classification
{
    public class VisualAcuityClassification : IClassifiable<VisualAcuityClassificationResult>
    {
        public VisualAcuityClassification(IVisualAcuity visualAcuity)
        {
            _visualAcuity = visualAcuity ?? throw new ArgumentNullException(nameof(visualAcuity));
        }

        public VisualAcuityClassificationResult Classification => ClassifyByPoorestVision();

        public VisualAcuityClassificationResult Near => Classify(_visualAcuity.Near);
        public VisualAcuityClassificationResult Distance => Classify(_visualAcuity.Distance);
        public VisualAcuityClassificationResult Both => Classify(_visualAcuity.Both);
        
        public override string ToString() => Classification.ToString();

        public static class LowerLimits
        {
            public static readonly int Normal = 20;
            public static readonly int NearNormal = 30;
            public static readonly int ModerateLowVision = 70;
            public static readonly int SevereLowVision = 200;
            public static readonly int ProfoundLowVision = 500;
            public static readonly int NearTotalBlindness = 1000;
        }
        
        private IVisualAcuity _visualAcuity;

        private VisualAcuityClassificationResult ClassifyByPoorestVision()
        {
            var visionList = new List<int>()
            {
                _visualAcuity.Near, 
                _visualAcuity.Distance, 
                _visualAcuity.Both
            };
            return Classify(visionList.Max());
        }
        
        private static VisualAcuityClassificationResult Classify(int viewDistance)
        {
            if (viewDistance < LowerLimits.Normal) return VisualAcuityClassificationResult.Ideal;
            if (viewDistance < LowerLimits.NearNormal) return VisualAcuityClassificationResult.Normal;
            if (viewDistance < LowerLimits.ModerateLowVision) return VisualAcuityClassificationResult.NearNormal;
            if (viewDistance < LowerLimits.SevereLowVision) return VisualAcuityClassificationResult.ModerateLowVision;
            if (viewDistance < LowerLimits.ProfoundLowVision) return VisualAcuityClassificationResult.SevereLowVision;
            return viewDistance < LowerLimits.NearTotalBlindness 
                ? VisualAcuityClassificationResult.ProfoundLowVision : VisualAcuityClassificationResult.NearTotalBlindness;
        }
    }
}