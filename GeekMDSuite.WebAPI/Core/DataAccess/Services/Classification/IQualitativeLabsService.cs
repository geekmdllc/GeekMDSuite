using GeekMDSuite.Core.LaboratoryData;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification
{
    public interface IQualitativeLabsService
        : IClassificationService<QualitativeLab, QualitativeLabResult>
    {
        
    }
}