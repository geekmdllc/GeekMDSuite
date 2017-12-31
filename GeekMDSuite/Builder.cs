namespace GeekMDSuite
{
    public abstract class Builder<TBuilder, TObj> : IBuilder<TObj> where TBuilder : new()
    {
        public static TBuilder Initialize() => new TBuilder();
        public abstract TObj Build();
        public abstract TObj BuildWithoutModelValidation();
    }
}