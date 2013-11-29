namespace SSW.Framework.Data.EF
{
    public interface IDbContextFactory<T>
    {
        T Build();
    }

}
