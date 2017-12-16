using System;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.Services.Repositories;

namespace GeekMDSuite.Services.Interpretation
{
    public class QuantitativeLabInterpretation : IInterpretable<QuantitativeLabResult>
    {

        public QuantitativeLabInterpretation(QuantitativeLab lab, IPatient patient)
        {
            _lab = lab;
            _patient = patient;
            Lab = QuantitativeLabRepository.GetLab(lab);
        }
        
        public QuantitativeLabInterpretationModel Lab { get; }

        public InterpretationText Interpretation => throw new NotImplementedException();
        public QuantitativeLabResult Classification => Classify();

        private QuantitativeLabResult Classify()
        {
            switch (Gender.IsGenotypeXx(_patient.Gender))
            {
                case true:
                    if (_lab.Result < Lab.LowerLimitOfLowFemale)
                        return QuantitativeLabResult.VeryLow;
                    else if (_lab.Result >= Lab.LowerLimitOfLowFemale &&
                             _lab.Result < Lab.LowerLimitOfNormalFemale)
                        return QuantitativeLabResult.Low;
                    else if (_lab.Result >= Lab.LowerLimitOfNormalFemale &&
                             _lab.Result <= Lab.UpperLimitOfNormalFemale)
                        return QuantitativeLabResult.Normal;
                    else if (_lab.Result > Lab.UpperLimitOfNormalFemale &&
                             _lab.Result <= Lab.UpperLimitOfHighFemale)
                        return QuantitativeLabResult.High;
                    else if (_lab.Result > Lab.UpperLimitOfHighFemale)
                        return QuantitativeLabResult.VeryHigh;
                    else
                        return QuantitativeLabResult.InvalidResult;
                default:
                    if (_lab.Result < Lab.LowerLimitOfLowMale)
                        return QuantitativeLabResult.VeryLow;
                    else if (_lab.Result >= Lab.LowerLimitOfLowMale &&
                             _lab.Result < Lab.LowerLimitOfNormalMale)
                        return QuantitativeLabResult.Low;
                    else if (_lab.Result >= Lab.LowerLimitOfNormalMale &&
                             _lab.Result <= Lab.UpperLimitOfNormalMale)
                        return QuantitativeLabResult.Normal;
                    else if (_lab.Result > Lab.UpperLimitOfNormalMale &&
                             _lab.Result <= Lab.UpperLimitOfHighMale)
                        return QuantitativeLabResult.High;
                    else if (_lab.Result > Lab.UpperLimitOfHighMale)
                        return QuantitativeLabResult.VeryHigh;
                    else
                        return QuantitativeLabResult.InvalidResult;
            }
        }
        private readonly QuantitativeLab _lab;
        private readonly IPatient _patient;
    }
}
