﻿using System;
using GeekMDSuite.Core.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class SpirometryEntity : Spirometry, IVisitData<Spirometry>
    {
        public SpirometryEntity()
        {
            
        }

        public SpirometryEntity(Spirometry spirometry)
        {
            MapValues(spirometry);
        }
        
        public void MapValues(Spirometry subject)
        {
            ForcedExpiratoryFlow25To75 = subject.ForcedExpiratoryFlow25To75;
            ForcedExpiratoryTime = subject.ForcedExpiratoryTime;
            ForcedExpiratoryVolume1Second = subject.ForcedExpiratoryVolume1Second;
            ForcedVitalCapacity = subject.ForcedVitalCapacity;
            PeakExpiratoryFlow = subject.PeakExpiratoryFlow;
        }

        public int Id { get; set; }
        public Guid Visit { get; set; }
    }
}