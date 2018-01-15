using System;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.WebAPI.Presentation.StubFromUserModels
{
    public class CarotidUltrasoundStubFromUser
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public CarotidUltrasoundResult Left { get; set; }
        public CarotidUltrasoundResult Right { get; set; }

        public CarotidUltrasoundStubFromUser()
        {
            Left = new CarotidUltrasoundResult();
            Right = new CarotidUltrasoundResult();
        }
    }
}