using System;
using GeekMDSuite.Core.LaboratoryData.Panels;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels.LaboratoryPanels
{
    public class ComprehensiveMetabolicPanelEntity : ComprehensiveMetabolicPanel, IMapProperties<ComprehensiveMetabolicPanel>, IVisitData
    {
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
        
        public void MapValues(ComprehensiveMetabolicPanel subject)
        {
            AlanineAminotransferase = subject.AlanineAminotransferase;
            Albumin = subject.Albumin;
            AlkalinePhosphatase = subject.AlkalinePhosphatase;
            AspartateAminotransferase = subject.AspartateAminotransferase;
            Bicarbonate = subject.Bicarbonate;
            BloodUreaNitrogen = subject.BloodUreaNitrogen;
            Chloride = subject.Chloride;
            Creatinine = subject.Creatinine;
            Glucose = subject.Glucose;
            Potassium = subject.Potassium;
            Sodium = subject.Sodium;
            TotalBilirubin = subject.TotalBilirubin;
            TotalProtein = subject.TotalProtein;
        }
    }
}