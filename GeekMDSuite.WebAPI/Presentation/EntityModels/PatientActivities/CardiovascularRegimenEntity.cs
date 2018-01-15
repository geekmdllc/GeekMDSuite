﻿using System;
using GeekMDSuite.Core.Models.PatientActivities;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels.PatientActivities
{
    public class CardiovascularRegimenEntity : CardiovascularRegimen, IMapProperties<CardiovascularRegimen>, IVisitData
    {
        public CardiovascularRegimenEntity()
        {
        }

        public CardiovascularRegimenEntity(CardiovascularRegimen regimen)
        {
            MapValues(regimen);
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }

        public void MapValues(CardiovascularRegimen subject)
        {
            AverageSessionDuration = subject.AverageSessionDuration;
            Intensity = subject.Intensity;
            SessionsPerWeek = subject.SessionsPerWeek;
        }
    }
}