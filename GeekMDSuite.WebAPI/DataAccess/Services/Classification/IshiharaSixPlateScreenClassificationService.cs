using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class IshiharaSixPlateScreenClassificationService : IIshiharaSixPlateScreenService
    {
        public IshiharaResultFlag Classify(IshiharaSixPlate obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new IshiharaSixPlateClassification(obj).Classification;
        }
    }
}