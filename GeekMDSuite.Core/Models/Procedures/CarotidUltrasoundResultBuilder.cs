using System;
using GeekMDSuite.Core.Builders;

namespace GeekMDSuite.Core.Models.Procedures
{
    public class CarotidUltrasoundResultBuilder : Builder<CarotidUltrasoundResultBuilder, CarotidUltrasoundResult>
    {
        private CarotidIntimaMediaThicknessGrade _imtGrade = CarotidIntimaMediaThicknessGrade.Normal;

        private double _imtThickenssMm;
        private CarotidPlaqueCharacter _plaqueCharacter = CarotidPlaqueCharacter.None;
        private CarotidPercentStenosisGrade _stenosisGrade = CarotidPercentStenosisGrade.None;

        public override CarotidUltrasoundResult Build()
        {
            ValidatePreBuildState();
            return BuildWithoutModelValidation();
        }

        public override CarotidUltrasoundResult BuildWithoutModelValidation()
        {
            return new CarotidUltrasoundResult
            {
                IntimaMediaMeasurementMillimeters = _imtThickenssMm,
                Grade = _imtGrade,
                Stenosis = _stenosisGrade,
                Character = _plaqueCharacter
            };
        }

        public CarotidUltrasoundResultBuilder SetIntimaMediaThickeness(double millimeters)
        {
            _imtThickenssMm = millimeters;
            return this;
        }

        public CarotidUltrasoundResultBuilder SetPercentStenosisGrade(CarotidPercentStenosisGrade grade)
        {
            _stenosisGrade = grade;
            return this;
        }

        public CarotidUltrasoundResultBuilder SetPlaqueCharacter(CarotidPlaqueCharacter character)
        {
            _plaqueCharacter = character;
            return this;
        }

        public CarotidUltrasoundResultBuilder SetImtGrade(CarotidIntimaMediaThicknessGrade grade)
        {
            _imtGrade = grade;
            return this;
        }

        private void ValidatePreBuildState()
        {
            if (Math.Abs(_imtThickenssMm - default(double)) < 0.001)
                throw new MissingMethodException(nameof(SetIntimaMediaThickeness) + " must be set.");
        }
    }
}