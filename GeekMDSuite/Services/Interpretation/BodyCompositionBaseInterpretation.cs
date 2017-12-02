using System;
using GeekMDSuite.Tools;
using GeekMDSuite.Tools.MeasurementUnits;

namespace GeekMDSuite.Services.Interpretation
{
    public abstract class BodyCompositionBaseInterpretation : IInterpretable
    {
        public BodyCompositionBaseInterpretation(IBodyComposition bodyComposition)
        {
            Height = bodyComposition.Height;
            Waist = bodyComposition.Waist;
            Hips = bodyComposition.Hips;
            Weight = bodyComposition.Weight;
        }

        protected  ILengthMeasurement Height { get; }
        protected ILengthMeasurement Waist { get; }
        protected ILengthMeasurement Hips { get; }
        protected IMassMeasurement Weight { get; }

        public virtual InterpretationText Interpretation => throw new NotImplementedException();
    }
}