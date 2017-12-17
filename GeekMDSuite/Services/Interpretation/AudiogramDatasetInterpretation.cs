﻿using System.Collections.Generic;
using System.Linq;
using GeekMDSuite.Procedures;

namespace GeekMDSuite.Services.Interpretation
{
    public class AudiogramDatasetInterpretation
    {

        public AudiogramDatasetInterpretation(AudiogramDataset dataset)
        {
            _audiogramDataset = dataset;
        }
        public HearingLoss Classification => AudiogramDataPointInterpretation.Classify(HighestDatapoint(_audiogramDataset));
        public static int HighestDatapoint(AudiogramDataset audiogramDataset)
        {
            var list = new List<int>
            {
                audiogramDataset.F125?.Value ?? 0,
                audiogramDataset.F250?.Value ?? 0,
                audiogramDataset.F500?.Value ?? 0,
                audiogramDataset.F1000?.Value ?? 0,
                audiogramDataset.F2000?.Value ?? 0,
                audiogramDataset.F3000?.Value ?? 0,
                audiogramDataset.F4000?.Value ?? 0,
                audiogramDataset.F6000?.Value ?? 0,
                audiogramDataset.F8000?.Value ?? 0
            };
            return list.Max();
        }
        
        private readonly AudiogramDataset _audiogramDataset;
    }
}