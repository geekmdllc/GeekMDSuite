namespace GeekMDSuite.Core.Builders
{
    public interface IBuilder<out TObj>
    {
        TObj Build();
        TObj BuildWithoutModelValidation();
    }
}