using System;
using GeekMDSuite.Core.Models.Procedures;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class CarotidUltrasoundStub : IStub
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public CarotidUltrasoundResult Left { get; set; }
        public CarotidUltrasoundResult Right { get; set; }

        public CarotidUltrasoundStub()
        {
            Left = new CarotidUltrasoundResult();
            Right = new CarotidUltrasoundResult();
        }
    }
}