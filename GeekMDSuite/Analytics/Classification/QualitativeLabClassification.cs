using System;
using GeekMDSuite.LaboratoryData;
using GeekMDSuite.Services.Repositories;

namespace GeekMDSuite.Analytics.Classification
{
    public class QualitativeLabClassification : IClassifiable<QualitativeLabResult>
    {
        public QualitativeLabClassification(IQualitativeLab lab, IPatient patient)
        {
            _lab = lab ?? throw new ArgumentNullException(nameof(lab));
            _patient = patient ?? throw new ArgumentNullException(nameof(patient));
            Lab = QualitativeLabRepository.GetLab(lab);
        }

        public QualitativeLabClassificationModel Lab { get; set; }

        private readonly IQualitativeLab _lab;
        private readonly IPatient _patient;
       
        public QualitativeLabResult Classification => _lab.Result;

        public override string ToString() => Lab + " - " + Classification.ToString();
    }
}