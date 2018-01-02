﻿using System;
using GeekMDSuite.Core.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class SitAndReachEntity : SitAndReach, IVisitData<SitAndReach>
    {
        public SitAndReachEntity() {}

        public SitAndReachEntity(SitAndReach sitAndReach)
        {
            MapValues(sitAndReach);
        }
        
        public void MapValues(SitAndReach subject) => Value = subject.Value;

        public int Id { get; set; }
        public Guid Visit { get; set; }
    }
}