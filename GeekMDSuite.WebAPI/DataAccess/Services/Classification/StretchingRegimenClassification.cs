using System;
using GeekMDSuite.Analytics.Classification.PatientActivities;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class StretchingRegimenClassificationService : IStretchingRegimenClassificationService
    {
        public StretchingRegimenClassification Classify(StretchingRegimen obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new StretchingRegimenClassification(obj);
        }
    }
}