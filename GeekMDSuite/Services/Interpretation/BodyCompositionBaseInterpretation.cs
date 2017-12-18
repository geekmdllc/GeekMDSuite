using System;
using GeekMDSuite.Tools;
using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Services.Interpretation
{
    public abstract class BodyCompositionBaseInterpretation
    {
        public BodyCompositionBaseInterpretation(IBodyComposition bodyCompositionExpanded)
        {
            Height = bodyCompositionExpanded.Height;
            Waist = bodyCompositionExpanded.Waist;
            Hips = bodyCompositionExpanded.Hips;
            Weight = bodyCompositionExpanded.Weight;
        }

        protected  ILengthMeasurement Height { get; }
        protected ILengthMeasurement Waist { get; }
        protected ILengthMeasurement Hips { get; }
        protected IMassMeasurement Weight { get; }

        public abstract InterpretationText Interpretation { get; }
    }
}