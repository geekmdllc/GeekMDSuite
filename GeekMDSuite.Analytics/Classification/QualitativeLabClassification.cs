using System;
using GeekMDSuite.Analytics.Repositories;
using GeekMDSuite.Core.LaboratoryData;

namespace GeekMDSuite.Analytics.Classification
{
    public class QualitativeLabClassification : IClassifiable<QualitativeLabResult>
    {
        private readonly QualitativeLab _lab;

        public QualitativeLabClassification(QualitativeLab lab)
        {
            _lab = lab ?? throw new ArgumentNullException(nameof(lab));
            Lab = QualitativeLabRepository.GetLab(lab);
        }

        public QualitativeLabClassificationModel Lab { get; set; }

        public QualitativeLabResult Classification => _lab.Result;

        public override string ToString()
        {
            return Lab + " - " + Classification;
        }
    }
}