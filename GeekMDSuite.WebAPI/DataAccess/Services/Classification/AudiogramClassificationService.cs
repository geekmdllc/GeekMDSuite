using System;
using GeekMDSuite.Analytics.Classification;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.DataAccess;
using GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification;

namespace GeekMDSuite.WebAPI.DataAccess.Services.Classification
{
    public class AudiogramClassificationService : IAudiogramClassificationService
    {
        public AudiogramClassificationResult Classify(Audiogram obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new AudiogramClassification(obj).Classification;
        }
    }
}