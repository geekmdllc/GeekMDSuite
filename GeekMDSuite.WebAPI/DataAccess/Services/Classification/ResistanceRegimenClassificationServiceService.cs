using GeekMDSuite.Analytics.Classification.PatientActivities;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class ResistanceRegimenClassificationServiceService : IResistanceRegimenClassificationService
    {
        public ResistanceRegimenClassification Classify(ResistanceRegimen obj)
        {
            return new ResistanceRegimenClassification(obj);
        }
    }
}