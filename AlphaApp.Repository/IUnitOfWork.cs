namespace AlphaApp.DataRepository
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
    }
}
