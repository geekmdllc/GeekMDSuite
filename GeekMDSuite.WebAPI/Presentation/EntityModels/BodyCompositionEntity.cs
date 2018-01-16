using System;
using GeekMDSuite.Core.Models;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels
{
    public class BodyCompositionEntity : BodyComposition, IMapProperties<BodyComposition>, IVisitData
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        
        public BodyCompositionEntity()
        {
            Guid = Guid.Empty;
        }

        public BodyCompositionEntity(BodyComposition bodyComposition) : this()
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
    }
}