using System;
using System.Linq;
using GeekMDSuite.Core.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.ClassificationService;

namespace GeekMDSuite.WebAPI.DataAccess.Services.ClassificationService
{
    public class BodyCompositionClassificationService :
        ClassificationService<BodyCompositionClassification, BodyCompositionClassificationResult>,
        IBodyCompositionClassificationService
    {
        public BodyCompositionClassificationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        
        public override ClassificationService<BodyCompositionClassification, BodyCompositionClassificationResult> InitializeWith(int id)
        {
            var bodyComposition = UnitOfWork.BodyCompositions.FindById(id);
            var visits = UnitOfWork.Visits.FindByVisit(bodyComposition.VisitId).FirstOrDefault();
            if (visits == null) 
                throw new NullReferenceException();
            
            var patient = UnitOfWork.Patients.FindByGuid(visits.PatientGuid);
            
            Classifier = new BodyCompositionClassification(bodyComposition, patient);
            
            return this;
        }
    }
}