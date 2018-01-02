namespace GeekMDSuite.Core
{
    public interface IBuilder<out TObj>
    {
        TObj Build();
        TObj BuildWithoutModelValidation();
    }
}