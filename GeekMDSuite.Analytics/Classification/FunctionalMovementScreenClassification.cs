using System;
using GeekMDSuite.Core.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class FunctionalMovementScreenClassification : IClassifiable<FunctionalMovementScreenClassificationResult>
    {
        public FunctionalMovementScreenClassification(IFunctionalMovementScreen fms)
        {
            _fms = fms ?? throw new ArgumentNullException(nameof(fms));
        }

        public FunctionalMovementScreenClassificationResult Classification => Classify();

        public override string ToString() => Classification.ToString();

        private readonly IFunctionalMovementScreen _fms;
        private FunctionalMovementScreenClassificationResult Classify()
        {
            return new FunctionalMovementScreenClassificationResult(_fms);
        }
    }
}