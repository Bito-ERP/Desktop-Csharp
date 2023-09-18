using ExampleApp.Domain.Configurations;
using ExampleApp.Domain.Entities.Products;
using ExampleApp.Service.DTOs;

namespace ExampleApp.Service.Interfaces;

public partial interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync(PaginationParams @params);
    Task<Product> GetAsync(Func<Product, bool> expression = null);
    Task<int> AddAsync(ProductForCreationDto dto);
    Task<int> UpdateAsync(int id, ProductForCreationDto dto);
    Task<int> DeleteAsync(Func<Product, bool> expression);
}