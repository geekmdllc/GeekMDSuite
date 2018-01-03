using System;
using GeekMDSuite.Analytics.Classification.CompositeScores;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.ClassificationService.CompositeScores;

namespace GeekMDSuite.WebAPI.DataAccess.Services.ClassificationService
{
    public class AscvdClassificationService :
        ClassificationService<AscvdClassification, AscvdClassificationResult>, IAscvdClassificationService
    {

        public AscvdClassificationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        public override ClassificationService<AscvdClassification, AscvdClassificationResult> InitializeWith(int id)
        {
            throw new NotImplementedException();
        }
    }
}