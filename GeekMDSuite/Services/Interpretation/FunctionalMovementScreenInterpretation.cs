using System;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class FunctionalMovementScreenInterpretation : IInterpretable<FunctionalMovementScreenClassification>
    {
        public FunctionalMovementScreenInterpretation(IFunctionalMovementScreen fms)
        {
            _fms = fms ?? throw new ArgumentNullException(nameof(fms));
        }
        
        public InterpretationText Interpretation => throw new NotImplementedException();
        public FunctionalMovementScreenClassification Classification => Classify();

        public override string ToString() => Classification.ToString();

        private readonly IFunctionalMovementScreen _fms;
        private FunctionalMovementScreenClassification Classify()
        {
            return new FunctionalMovementScreenClassification(_fms);
        }
    }
}