namespace GeekMDSuite
{
    public interface IBuilder<out T>
    {
        T Build();
    }
}