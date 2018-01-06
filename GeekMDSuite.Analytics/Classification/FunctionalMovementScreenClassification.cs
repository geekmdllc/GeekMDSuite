using System;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.Analytics.Classification
{
    public class FunctionalMovementScreenClassification : IClassifiable<FunctionalMovementScreenClassificationResult>
    {
        private readonly FunctionalMovementScreen _fms;

        public FunctionalMovementScreenClassification(FunctionalMovementScreen fms)
        {
            _fms = fms ?? throw new ArgumentNullException(nameof(fms));
        }

        public FunctionalMovementScreenClassificationResult Classification => Classify();

        public override string ToString()
        {
            return Classification.ToString();
        }

        private FunctionalMovementScreenClassificationResult Classify()
        {
            return new FunctionalMovementScreenClassificationResult(_fms);
        }
    }
}