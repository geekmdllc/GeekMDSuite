using System;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.Services.Repositories;

namespace GeekMDSuite.Services.Interpretation
{
    public class QualitativeLabInterpretation : IInterpretable<QualitativeLabResult>
    {
        public QualitativeLabInterpretation(IQualitativeLab lab, IPatient patient)
        {
            _lab = lab ?? throw new ArgumentNullException(nameof(lab));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            Lab = QualitativeLabRepository.GetLab(lab);
        }

        public QualitativeLabInterpretationModel Lab { get; set; }

        private readonly IQualitativeLab _lab;
        private readonly IPatient _patient;
        
        public InterpretationText Interpretation => throw new NotImplementedException();
        public QualitativeLabResult Classification => _lab.Result;

        public override string ToString() => Lab + " - " + Classification.ToString();
    }
}