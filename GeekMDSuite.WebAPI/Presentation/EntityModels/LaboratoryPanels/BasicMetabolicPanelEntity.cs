using System;
using GeekMDSuite.Core.LaboratoryData.Panels;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels.LaboratoryPanels
{
    public class BasicMetabolicPanelEntity : BasicMetabolicPanel, IMapProperties<BasicMetabolicPanel>, IVisitData
    {
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }

        public void MapValues(BasicMetabolicPanel subject)
        {
            Bicarbonate = subject.Bicarbonate;
            BloodUreaNitrogen = subject.BloodUreaNitrogen;
            Chloride = subject.Chloride;
            Creatinine = subject.Creatinine;
            Glucose = subject.Glucose;
            Potassium = subject.Potassium;
            Sodium = subject.Sodium;
        }
    }
}