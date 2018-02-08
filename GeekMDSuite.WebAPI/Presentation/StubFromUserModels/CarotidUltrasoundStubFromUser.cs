using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;
using GeekMDSuite.WebAPI.Presentation.StubModels;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class CarotidUltrasoundStubFromUser : IVisitData
    {
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
        public CarotidUltrasoundResult Left { get; set; }
        public CarotidUltrasoundResult Right { get; set; }

        public CarotidUltrasoundStubFromUser()
        {
            Left = new CarotidUltrasoundResult();
            Right = new CarotidUltrasoundResult();
        }
    }
}