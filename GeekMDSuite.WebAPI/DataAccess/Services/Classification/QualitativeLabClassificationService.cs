using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.LaboratoryData;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class QualitativeLabClassificationService : IQualitativeLabsClassificationService
    {
        public QualitativeLabResult Classify(QualitativeLab obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new QualitativeLabClassification(obj).Classification;
        }
    }
}