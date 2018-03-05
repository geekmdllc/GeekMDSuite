using GeekMDSuite.Analytics.Classification.PatientActivities;
using GeekMDSuite.Core.Models.PatientActivities;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification
{
    public interface ICardiovascularRegimenClassificationService
        : IClassificationService<ExerciseRegimenClassification, CardiovascularRegimenClassification>
    {
        
    }
}