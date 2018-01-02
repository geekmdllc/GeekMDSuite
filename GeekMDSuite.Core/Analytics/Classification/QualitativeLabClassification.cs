using System;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.Core.Services.Repositories;

namespace GeekMDSuite.Core.Analytics.Classification
{
    public class QualitativeLabClassification : IClassifiable<QualitativeLabResult>
    {
        public QualitativeLabClassification(IQualitativeLab lab)
        {
            _lab = lab ?? throw new ArgumentNullException(nameof(lab));
            Lab = QualitativeLabRepository.GetLab(lab);
        }

        public QualitativeLabClassificationModel Lab { get; set; }

        private readonly IQualitativeLab _lab;

        public QualitativeLabResult Classification => _lab.Result;

        public override string ToString() => Lab + " - " + Classification.ToString();
    }
}