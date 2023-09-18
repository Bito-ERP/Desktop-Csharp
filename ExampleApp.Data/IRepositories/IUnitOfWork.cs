namespace ExampleApp.Data.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
}