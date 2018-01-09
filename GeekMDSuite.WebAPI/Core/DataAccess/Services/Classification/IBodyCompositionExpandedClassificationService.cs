﻿using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification
{
    public interface IBodyCompositionExpandedClassificationService
        : IClassificationService<BodyCompositionExpandedClassificationParameters, BodyCompositionClassificationResult>
    {
        
    }
}