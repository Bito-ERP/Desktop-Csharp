using BitoDesktop.Domain.Configurations;
using BitoDesktop.Domain.Entities.Products;
using BitoDesktop.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Interfaces;

public partial interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync(PaginationParams @params);
    Task<Product> GetAsync(Func<Product, bool> expression = null);
    Task<int> AddAsync(ProductForCreationDto dto);
    Task<bool> AddApiAsync(ProductForCreationDto dto);
    Task<int> UpdateAsync(int id, ProductForCreationDto dto);
    Task<int> DeleteAsync(Func<Product, bool> expression);
}