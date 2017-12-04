using System;
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

        public InterpretationText Interpretation => throw new NotImplementedException();
        
        public CarotidUltrasoundInterpretationResult Classification => ClassifyCarotidUltrasound();

        private CarotidUltrasoundInterpretationResult ClassifyCarotidUltrasound()
        {
            var laterality = GetLaterality();
            var grade = GetStenosisGrade();

            return new CarotidUltrasoundInterpretationResult(laterality, grade);
        }

        private CarotidPercentStenosisGrade GetStenosisGrade()
        {
            if (_carotidUltrasound.Left.Stenosis > _carotidUltrasound.Right.Stenosis)
                return _carotidUltrasound.Left.Stenosis;
            return _carotidUltrasound.Left.Stenosis < _carotidUltrasound.Right.Stenosis 
                ? _carotidUltrasound.Right.Stenosis : _carotidUltrasound.Left.Stenosis;
        }

        private Laterality GetLaterality()
        {
            if (_carotidUltrasound.Left.Stenosis > _carotidUltrasound.Right.Stenosis)
                return Laterality.Left;
            return _carotidUltrasound.Left.Stenosis < _carotidUltrasound.Right.Stenosis 
                ? Laterality.Right : Laterality.Bilateral;
        }
    }
}