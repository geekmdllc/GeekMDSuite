using System;
using GeekMDSuite.Core.LaboratoryData.Panels;
using GeekMDSuite.WebAPI.Core.Models;

namespace GeekMDSuite.WebAPI.Presentation.EntityModels.LaboratoryPanels
{
    public class CompleteBloodCountEntity : CompleteBloodCount, IMapProperties<CompleteBloodCount>, IVisitData
    {
        public void MapValues(CompleteBloodCount subject)
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
        }

        public int Id { get; set; }
        public Guid VisitGuid { get; set; }
    }
}