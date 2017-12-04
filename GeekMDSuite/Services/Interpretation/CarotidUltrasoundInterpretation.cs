using System;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class CarotidUltrasoundInterpretation : IInterpretable<CarotidPercentStenosisGrade>
    {
        public CarotidUltrasoundInterpretation(CarotidUltrasound carotidUltrasound)
        {
            
        }

        public InterpretationText Interpretation => throw new NotImplementedException();
        public CarotidPercentStenosisGrade Classification { get; }
    }
}