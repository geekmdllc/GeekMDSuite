using System;
using GeekMDSuite.Core.Procedures;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class IshiharaSixPlateEntity : IshiharaSixPlate, IVisitData<IshiharaSixPlate>
    {
        public int Id { get; set; }
        public Guid VisitId { get; set; }

        public IshiharaSixPlateEntity()
        {
        }

        public IshiharaSixPlateEntity(IshiharaSixPlate ishiharaSixPlate)
        {
            MapValues(ishiharaSixPlate);
        }
        public void MapValues(IshiharaSixPlate subject)
        {
            if (subject == null) throw new ArgumentNullException(nameof(subject));
            Plate1.PlateNumber = subject.Plate1.PlateNumber;
            Plate1.PlateRead = subject.Plate1.PlateRead;
            Plate2.PlateNumber = subject.Plate2.PlateNumber;
            Plate2.PlateRead = subject.Plate2.PlateRead;
            Plate3.PlateNumber = subject.Plate3.PlateNumber;
            Plate3.PlateRead = subject.Plate3.PlateRead;
            Plate4.PlateNumber = subject.Plate4.PlateNumber;
            Plate4.PlateRead = subject.Plate5.PlateRead;
            Plate5.PlateNumber = subject.Plate5.PlateNumber;
            Plate5.PlateRead = subject.Plate5.PlateRead;
            Plate6.PlateNumber = subject.Plate6.PlateNumber;
            Plate6.PlateRead = subject.Plate6.PlateRead;
        }
    }
}