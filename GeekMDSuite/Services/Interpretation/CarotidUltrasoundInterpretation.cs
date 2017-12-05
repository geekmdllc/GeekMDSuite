using System;
using System.Collections.Generic;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class CarotidUltrasoundInterpretation : IInterpretable<CarotidUltrasoundInterpretationResult>
    {
        private readonly CarotidUltrasound _carotidUltrasound;

        public CarotidUltrasoundInterpretation(CarotidUltrasound carotidUltrasound)
        {
            _carotidUltrasound = carotidUltrasound;
        }
        
        //todo: ensure that this incorporates IMT and character
        public InterpretationText Interpretation => throw new NotImplementedException();
        
        public CarotidUltrasoundInterpretationResult Classification => ClassifyCarotidUltrasound();

        private CarotidUltrasoundInterpretationResult ClassifyCarotidUltrasound()
        {
            return new CarotidUltrasoundInterpretationResult(
                GetLateralityOfSidesAffected(), 
                GetWorseSideBasedOnStenosis(), 
                GetStenosisGradeFromWorseSide(),
                GetPlaqueCharacterFromWorseSide());
        }

        private CarotidPercentStenosisGrade GetStenosisGradeFromWorseSide()
        {
            var left = _carotidUltrasound.Left.Stenosis;
            var right = _carotidUltrasound.Right.Stenosis;
            
            return StenosisSeverityMapToRelativeValue[left] >= StenosisSeverityMapToRelativeValue[right] ? left : right;
        }

        private Laterality GetWorseSideBasedOnStenosis()
        {
            var left = _carotidUltrasound.Left.Stenosis;
            var right = _carotidUltrasound.Right.Stenosis;

            if (StenosisSeverityMapToRelativeValue[left] == StenosisSeverityMapToRelativeValue[right])
                return Laterality.Bilateral;

            return StenosisSeverityMapToRelativeValue[left] > StenosisSeverityMapToRelativeValue[right] 
                ? Laterality.Left : Laterality.Right;
        }

        private Laterality GetLateralityOfSidesAffected()
        {
            var left = _carotidUltrasound.Left.Stenosis;
            var right = _carotidUltrasound.Right.Stenosis;

            if (left == CarotidPercentStenosisGrade.None && 
                right == CarotidPercentStenosisGrade.None || 
                StenosisSeverityMapToRelativeValue[left] == StenosisSeverityMapToRelativeValue[right]) 
                return Laterality.Bilateral;
            
            return StenosisSeverityMapToRelativeValue[left] > StenosisSeverityMapToRelativeValue[right]  
                ? Laterality.Left : Laterality.Right;
        }

        private CarotidPlaqueCharacter GetPlaqueCharacterFromWorseSide()
        {
            var left = _carotidUltrasound.Left.Character;
            var right = _carotidUltrasound.Right.Character;
            
            return PlaqueSeverityMapToRelativeValue[left] >= PlaqueSeverityMapToRelativeValue[right] 
                ? _carotidUltrasound.Left.Character : _carotidUltrasound.Right.Character;
        }
        
        private static Dictionary<CarotidPlaqueCharacter, int> PlaqueSeverityMapToRelativeValue => 
            new Dictionary<CarotidPlaqueCharacter, int>()
            {
                {CarotidPlaqueCharacter.None, 0},
                {CarotidPlaqueCharacter.EarlyBuildup, 1},
                {CarotidPlaqueCharacter.Calcified, 2},
                {CarotidPlaqueCharacter.Mixed, 3},
                {CarotidPlaqueCharacter.Soft, 4}
            };
        
        private static Dictionary<CarotidPercentStenosisGrade, int> StenosisSeverityMapToRelativeValue =>
            new Dictionary<CarotidPercentStenosisGrade, int>()
            {
                {CarotidPercentStenosisGrade.None, 0},
                {CarotidPercentStenosisGrade.Nominal, 1},
                {CarotidPercentStenosisGrade.LessThan30, 2},
                {CarotidPercentStenosisGrade.LessThan50, 3},
                {CarotidPercentStenosisGrade.MoreThan50, 4}
            };
        
        private static Dictionary<CarotidIntimaMediaThicknessGrade, int> ImtSeverityMapToRelativeValue =>
            new Dictionary<CarotidIntimaMediaThicknessGrade, int>()
            {
                {CarotidIntimaMediaThicknessGrade.Normal, 0},
                {CarotidIntimaMediaThicknessGrade.Mild, 1},
                {CarotidIntimaMediaThicknessGrade.Moderate, 2},
                {CarotidIntimaMediaThicknessGrade.Significant, 3},
                {CarotidIntimaMediaThicknessGrade.CriticalSignificant, 4}
            };
    }
}