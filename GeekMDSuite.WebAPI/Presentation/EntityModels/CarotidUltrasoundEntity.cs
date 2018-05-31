﻿using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class CarotidUltrasoundEntity : CarotidUltrasound, IMapProperties<CarotidUltrasound>, IVisitData
    {
        public CarotidUltrasoundEntity(CarotidUltrasound carotidUltrasound) : this()
        {
            Left = carotidUltrasound.Left;
            Right = carotidUltrasound.Right;
        }

        public CarotidUltrasoundEntity()
        {
            Left = new CarotidUltrasoundResult();
            Right = new CarotidUltrasoundResult();
            VisitGuid = Guid.Empty;
        }

        public void MapValues(CarotidUltrasound subject)
        {
            Left.Character = subject.Left.Character;
            Left.Grade = subject.Left.Grade;
            Left.IntimaMediaMeasurementMillimeters = subject.Left.IntimaMediaMeasurementMillimeters;
            Left.Stenosis = subject.Left.Stenosis;

            Right.Character = subject.Right.Character;
            Right.Grade = subject.Right.Grade;
            Right.IntimaMediaMeasurementMillimeters = subject.Right.IntimaMediaMeasurementMillimeters;
            Right.Stenosis = subject.Right.Stenosis;
        }

        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}