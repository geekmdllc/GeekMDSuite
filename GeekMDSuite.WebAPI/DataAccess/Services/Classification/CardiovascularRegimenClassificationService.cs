using System;
using GeekMDSuite.Analytics.Classification.PatientActivities;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class CardiovascularRegimenClassificationService : ICardiovascularRegimenClassificationService
    {
        public CardiovascularRegimenClassification Classify(CardiovascularRegimen obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return new CardiovascularRegimenClassification(obj);
        }
    }
}