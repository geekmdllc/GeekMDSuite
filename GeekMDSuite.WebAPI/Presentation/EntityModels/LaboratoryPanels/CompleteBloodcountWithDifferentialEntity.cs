using System;
using GeekMDSuite.Core.LaboratoryData.Panels;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels.LaboratoryPanels
{
    public class CompleteBloodcountWithDifferentialEntity : CompleteBloodCountWithDifferential, IMapProperties<CompleteBloodCountWithDifferential>, IVisitData
    {
        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
        
        public void MapValues(CompleteBloodCountWithDifferential subject)
        {
            Hematocrit = subject.Hematocrit;
            Hemoglobin = subject.Hemoglobin;
            MeanCorpuscularHemoglobin = subject.MeanCorpuscularHemoglobin;
            MeanCorpuscularHemoglobinConcentration = subject.MeanCorpuscularHemoglobinConcentration;
            MeanCorpuscularVolume = subject.MeanCorpuscularVolume;
            Platelets = subject.Platelets;
            RedBloodCells = subject.RedBloodCells;
            RedCellDistributionWidth = subject.RedCellDistributionWidth;
            WhiteBloodCells = subject.WhiteBloodCells;
            Basophils = subject.Basophils;
            Eosinophils = subject.Eosinophils;
            Lymphocytes = subject.Lymphocytes;
            Monocytes = subject.Monocytes;
            Neutrophils = subject.Neutrophils;
        }
    }
}