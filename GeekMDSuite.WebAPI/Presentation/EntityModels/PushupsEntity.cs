﻿using System;
using GeekMDSuite.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class PushupsEntity : Pushups, IVisitData<Pushups>
    {
        public PushupsEntity() {}

        public PushupsEntity(Pushups pushups)
        {
            MapValues(pushups);
        }
        public void MapValues(Pushups subject)
        {
            Value = subject.Value;
        }

        public int Id { get; set; }
        public Guid Visit { get; set; }
    }
}