using System;

namespace BitoDesktop.Data.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
}