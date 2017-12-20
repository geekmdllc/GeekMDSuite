namespace GeekMDSuite
{
    public interface IBuilder<out TObj>
    {
        TObj Build();
    }
}