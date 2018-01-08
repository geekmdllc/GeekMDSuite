namespace GeekMDSuite.WebAPI.Core.DataAccess.Services.Classification
{
    public interface IClassificationService<in TObj, out TResult> where TObj : class
    {
        TResult Classify(TObj obj);
    }
}