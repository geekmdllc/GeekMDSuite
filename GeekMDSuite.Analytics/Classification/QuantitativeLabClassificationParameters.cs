using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Classification
{
    public class QuantitativeLabClassificationParameters
    {
        public QuantitativeLabClassificationParameters(QuantitativeLab lab, Patient patient)
        {
            Lab = lab;
            Patient = patient;
        }

        public QuantitativeLab Lab { get; }
        public Patient Patient { get; }
    }
}