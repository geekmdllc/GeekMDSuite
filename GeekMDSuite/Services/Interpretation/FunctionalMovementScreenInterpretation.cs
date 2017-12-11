using System;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class FunctionalMovementScreenInterpretation : IInterpretable<FunctionalMovementScreenClassification>
    {
        public FunctionalMovementScreenInterpretation(FunctionalMovementScreen fms)
        {
            _fms = fms;
        }
        
        public InterpretationText Interpretation => throw new NotImplementedException();
        public FunctionalMovementScreenClassification Classification => Classify();

        private readonly FunctionalMovementScreen _fms;
        private FunctionalMovementScreenClassification Classify()
        {
            return new FunctionalMovementScreenClassification(_fms);
        }
        

    }
    
    
}