using BitoDesktop.Data.IRepositories;
using System;

namespace BitoDesktop.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IProductRepository productRepository)
    {
        Products = productRepository;
    }

    /// <summary>
    /// Dbsets of database
    /// </summary>
    public IProductRepository Products { get; }
    /// <summary>
    /// Dispose object
    /// </summary>
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}