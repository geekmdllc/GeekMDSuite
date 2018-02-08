using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class CarotidUltrasoundStub : IVisitData
    {
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
        public CarotidUltrasoundResult Left { get; set; }
        public CarotidUltrasoundResult Right { get; set; }

        public CarotidUltrasoundStub()
        {
            Left = new CarotidUltrasoundResult();
            Right = new CarotidUltrasoundResult();
        }
    }
}