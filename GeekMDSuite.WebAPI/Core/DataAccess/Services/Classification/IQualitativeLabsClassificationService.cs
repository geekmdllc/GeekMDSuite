using GeekMDSuite.Core.LaboratoryData;

namespace GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification
{
    public interface IQualitativeLabsClassificationService
        : IClassificationService<QualitativeLab, QualitativeLabResult>
    {
    }
}