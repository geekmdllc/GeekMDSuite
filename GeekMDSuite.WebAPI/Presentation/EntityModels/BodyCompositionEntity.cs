using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class BodyCompositionEntity : BodyComposition, IVisitData<BodyComposition>
    {
        public BodyCompositionEntity()
        {
        }

        public BodyCompositionEntity(BodyComposition bodyComposition)
        {
            MapValues(bodyComposition);
        }

        public void MapValues(BodyComposition subject)
        {
            Height.Inches = subject.Height.Inches;
            Hips.Inches = subject.Height.Inches;
            Waist.Inches = subject.Waist.Inches;
            Weight.Pounds = subject.Weight.Pounds;
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
    }
}