﻿using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class PushupsClassificationService : IPushupsClassificationService
    {
        public FitnessClassification Classify(PushupsClassificationParameters obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new PushupsClassification(obj).Classification;
        }
    }
}