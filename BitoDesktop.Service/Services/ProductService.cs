using AutoMapper;
using BitoDesktop.Data.IRepositories;
using BitoDesktop.Domain.Configurations;
using BitoDesktop.Domain.Entities.Products;
using BitoDesktop.Service.DTOs;
using BitoDesktop.Service.Exceptions;
using BitoDesktop.Service.Extensions;
using BitoDesktop.Service.Helpers;
using BitoDesktop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services;

public partial class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Product>> GetAllAsync(PaginationParams @params)
    {
        throw new MarketException(404, "Product not found");
    }

    public async Task<Product> GetAsync(Func<Product, bool> expression = null)
    {
        throw new MarketException(404, "Product not found");
    }

    public async Task<int> AddAsync(ProductForCreationDto dto)
    {
        throw new MarketException(404, "Product not found");
    }

    public async Task<int> UpdateAsync(int id, ProductForCreationDto dto)
    {
        throw new MarketException(404, "Product not found");
    }

    public async Task<int> DeleteAsync(Func<Product, bool> expression)
    {
        throw new MarketException(404, "Product not found");
    }
}