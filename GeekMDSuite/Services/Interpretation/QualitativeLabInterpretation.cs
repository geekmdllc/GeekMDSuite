using System;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.Services.Repositories;

namespace GeekMDSuite.Services.Interpretation
{
    public class QualitativeLabInterpretation : IInterpretable<QualitativeLabResult>
    {
        public QualitativeLabInterpretation(QualitativeLab lab, IPatient patient)
        {
            _lab = lab;
            _patient = patient;
            Lab = QualitativeLabRepository.GetLab(lab);
        }

        public QualitativeLabInterpretationModel Lab { get; set; }

        private readonly QualitativeLab _lab;
        private readonly IPatient _patient;
        
        public InterpretationText Interpretation => throw new NotImplementedException();
        public QualitativeLabResult Classification => _lab.Result;

        public override string ToString() => Lab.ToString() + " - " + Classification.ToString();
    }
}