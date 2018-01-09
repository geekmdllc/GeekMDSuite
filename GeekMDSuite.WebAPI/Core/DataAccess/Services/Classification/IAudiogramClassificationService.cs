﻿using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification
{
    public interface IAudiogramClassificationService : IClassificationService<Audiogram, AudiogramClassificationResult>
    {
    }
}