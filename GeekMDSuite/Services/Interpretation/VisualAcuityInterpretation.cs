using System;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class VisualAcuityInterpretation : IInterpretable<VisualAcuityClassification>
    {
        public VisualAcuityInterpretation(VisualAcuity visualAcuity)
        {
            _visualAcuity = visualAcuity ?? throw new ArgumentNullException(nameof(visualAcuity));
        }

        public InterpretationText Interpretation => throw new NotImplementedException();
        public VisualAcuityClassification Classification => ClassifyByPoorestVision();

        public VisualAcuityClassification Near => Classify(_visualAcuity.Near);
        public VisualAcuityClassification Distance => Classify(_visualAcuity.Distance);
        public VisualAcuityClassification Both => Classify(_visualAcuity.Both);

        public static class LowerLimits
        {
            public static readonly int Normal = 20;
            public static readonly int NearNormal = 30;
            public static readonly int ModerateLowVision = 70;
            public static readonly int SevereLowVision = 200;
            public static readonly int ProfoundLowVision = 500;
            public static readonly int NearTotalBlindness = 1000;
        }
        
        private VisualAcuity _visualAcuity;
        
        private VisualAcuityClassification ClassifyByPoorestVision() => 
            Classify(_visualAcuity.Distance > _visualAcuity.Near ? _visualAcuity.Distance : _visualAcuity.Near);
        
        private static VisualAcuityClassification Classify(int viewDistance)
        {
            if (viewDistance < LowerLimits.Normal) return VisualAcuityClassification.Ideal;
            if (viewDistance < LowerLimits.NearNormal) return VisualAcuityClassification.Normal;
            if (viewDistance < LowerLimits.ModerateLowVision) return VisualAcuityClassification.NearNormal;
            if (viewDistance < LowerLimits.SevereLowVision) return VisualAcuityClassification.ModerateLowVision;
            if (viewDistance < LowerLimits.ProfoundLowVision) return VisualAcuityClassification.SevereLowVision;
            return viewDistance < LowerLimits.NearTotalBlindness 
                ? VisualAcuityClassification.ProfoundLowVision : VisualAcuityClassification.NearTotalBlindness;
        }
    }
}