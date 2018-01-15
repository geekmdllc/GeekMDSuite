using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.StubModels
{
    public class IshiharaSixPlateStub : IVisitData
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public IshiharaPlateAnswer Plate1 { get; set; }
        public IshiharaPlateAnswer Plate2 { get; set; }
        public IshiharaPlateAnswer Plate3 { get; set; }
        public IshiharaPlateAnswer Plate4 { get; set; }
        public IshiharaPlateAnswer Plate5 { get; set; }
        public IshiharaPlateAnswer Plate6 { get; set; }

        public IshiharaSixPlateStub()
        {
            Plate1 = new IshiharaPlateAnswer();
            Plate2 = new IshiharaPlateAnswer();
            Plate3 = new IshiharaPlateAnswer();
            Plate4 = new IshiharaPlateAnswer();
            Plate5 = new IshiharaPlateAnswer();
            Plate6 = new IshiharaPlateAnswer();
        }
    }
}