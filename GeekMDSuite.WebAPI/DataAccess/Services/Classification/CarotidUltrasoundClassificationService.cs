using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class CarotidUltrasoundClassificationService : ICarotidUltrasoundClassificationService
    {
        public CarotidUltrasoundClassificationResult Classify(CarotidUltrasound obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new CarotidUltrasoundClassification(obj).Classification;
        }
    }
}