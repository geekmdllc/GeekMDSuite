using System;
using GeekMDSuite.Core;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class BodyCompositionExpandedEntity : BodyCompositionExpanded, IVisitData<BodyCompositionExpanded>
    {
        public BodyCompositionExpandedEntity() { }

        public BodyCompositionExpandedEntity(BodyCompositionExpanded bodyCompositionExpanded) : this()
        {
            MapValues(bodyCompositionExpanded);
        }
        public void MapValues(BodyCompositionExpanded subject)
        {
            Height.Inches = subject.Height.Inches;
            Hips.Inches = subject.Height.Inches;
            Waist.Inches = subject.Waist.Inches;
            Weight.Pounds = subject.Weight.Pounds;
            PercentBodyFat = subject.PercentBodyFat;
            VisceralFat = subject.VisceralFat;
        }

        public int Id { get; set; }
        public Guid Visit { get; set; }
    }
}