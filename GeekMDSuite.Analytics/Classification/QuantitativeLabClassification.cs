using System;
using GeekMDSuite.Analytics.Repositories;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.Analytics.Classification
{
    public class QuantitativeLabClassification : IClassifiable<QuantitativeLabResult>
    {
        private readonly QuantitativeLab _lab;
        private readonly Patient _patient;

        public QuantitativeLabClassification(QuantitativeLab lab, Patient patient)
        {
            _lab = lab ?? throw new ArgumentNullException(nameof(lab));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            Lab = QuantitativeLabRepository.GetLab(lab);
        }

        public QuantitativeLabClassificationModel Lab { get; }

        public QuantitativeLabResult Classification => Classify();

        public override string ToString()
        {
            return
                $"Lab - {_lab.Result} {Lab.UnitsUs} ({Classification}) [{GetLowerBound()} - {GetUpperBound()} {Lab.UnitsUs}]";
        }

        private double GetUpperBound()
        {
            return Gender.IsGenotypeXx(_patient.Gender)
                ? Lab.UpperLimitOfNormalFemale
                : Lab.UpperLimitOfNormalMale;
        }

        private double GetLowerBound()
        {
            return Gender.IsGenotypeXx(_patient.Gender)
                ? Lab.LowerLimitOfNormalFemale
                : Lab.LowerLimitOfNormalMale;
        }

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
    }
}