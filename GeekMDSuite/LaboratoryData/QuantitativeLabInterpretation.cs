using System;
using System.Linq;
using GeekMDSuite.Services.Interpretation;
using GeekMDSuite.Services.Repositories;
using GeekMDSuite.Tools.Generic;

namespace GeekMDSuite.LaboratoryData
{
    public class QuantitativeLabInterpretation : IInterpretable<LaboratoryResult>
    {

        public QuantitativeLabInterpretation(QuantitativeLab lab, IPatient patient)
        {
            _lab = lab;
            _patient = patient;
            Lab = QuantitativeLabRepository.GetLab(lab);
        }
        
        public QuantitativeLabInterpretationModel Lab { get; }

        public InterpretationText Interpretation => throw new NotImplementedException();
        public LaboratoryResult Classification => Classify();

        private LaboratoryResult Classify()
        {
            switch (Gender.IsGenotypeXx(_patient.Gender))
            {
                case true:
                    if (_lab.Result < Lab.LowerLimitOfLowFemale)
                        return LaboratoryResult.VeryLow;
                    else if (_lab.Result >= Lab.LowerLimitOfLowFemale &&
                             _lab.Result < Lab.LowerLimitOfNormalFemale)
                        return LaboratoryResult.Low;
                    else if (_lab.Result >= Lab.LowerLimitOfNormalFemale &&
                             _lab.Result <= Lab.UpperLimitOfNormalFemale)
                        return LaboratoryResult.Normal;
                    else if (_lab.Result > Lab.UpperLimitOfNormalFemale &&
                             _lab.Result <= Lab.UpperLimitOfHighFemale)
                        return LaboratoryResult.High;
                    else if (_lab.Result > Lab.UpperLimitOfHighFemale)
                        return LaboratoryResult.VeryHigh;
                    else
                        return LaboratoryResult.InvalidResult;
                default:
                    if (_lab.Result < Lab.LowerLimitOfLowMale)
                        return LaboratoryResult.VeryLow;
                    else if (_lab.Result >= Lab.LowerLimitOfLowMale &&
                             _lab.Result < Lab.LowerLimitOfNormalMale)
                        return LaboratoryResult.Low;
                    else if (_lab.Result >= Lab.LowerLimitOfNormalMale &&
                             _lab.Result <= Lab.UpperLimitOfNormalMale)
                        return LaboratoryResult.Normal;
                    else if (_lab.Result > Lab.UpperLimitOfNormalMale &&
                             _lab.Result <= Lab.UpperLimitOfHighMale)
                        return LaboratoryResult.High;
                    else if (_lab.Result > Lab.UpperLimitOfHighMale)
                        return LaboratoryResult.VeryHigh;
                    else
                        return LaboratoryResult.InvalidResult;
            }
        }
        private readonly QuantitativeLab _lab;
        private readonly IPatient _patient;
    }
}
