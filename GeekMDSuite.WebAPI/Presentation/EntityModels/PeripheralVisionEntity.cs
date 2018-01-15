using System;
using GeekMDSuite.Core.Models.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class PeripheralVisionEntity : PeripheralVision, IMapProperties<PeripheralVision>, IVisitData
    {
        public PeripheralVisionEntity()
        {
        }

        public PeripheralVisionEntity(PeripheralVision peripheralVision)
        {
            MapValues(peripheralVision);
        }

        public void MapValues(PeripheralVision subject)
        {
            Left = subject.Left;
            Right = subject.Right;
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
    }
}