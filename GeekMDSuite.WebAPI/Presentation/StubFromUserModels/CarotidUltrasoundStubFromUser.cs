using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class CarotidUltrasoundStubFromUser : IVisitData
    {
        public CarotidUltrasoundStubFromUser()
        {
            Left = new CarotidUltrasoundResult();
            Right = new CarotidUltrasoundResult();
        }

        public CarotidUltrasoundResult Left { get; set; }
        public CarotidUltrasoundResult Right { get; set; }
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}