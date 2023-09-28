using AutoMapper;
using BitoDesktop.Data.IRepositories;
using BitoDesktop.Domain.Configurations;
using BitoDesktop.Domain.Entities.Products;
using BitoDesktop.Domain.Settings;
using BitoDesktop.Service.DTOs;
using BitoDesktop.Service.Exceptions;
using BitoDesktop.Service.Extensions;
using BitoDesktop.Service.Helpers;
using BitoDesktop.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        var pagedList = (await _unitOfWork.Products.GetAllAsync()).ToPagedList(@params);

        return pagedList;
    }

    public async Task<Product> GetAsync(Func<Product, bool> expression = null)
    {
        var product = (await _unitOfWork.Products.GetAllAsync()).FirstOrDefault(expression);
        if (product is null)
            throw new MarketException(404, "Product not found");

        return product;
    }

    public async Task<int> AddAsync(ProductForCreationDto dto)
    {    
        var mappedProduct = _mapper.Map<Product>(dto);
        var result = await _unitOfWork.Products.AddAsync(mappedProduct);

        return result;
    }
    public async Task<int> UpdateAsync(int id, ProductForCreationDto dto)
    {
        var product = (await _unitOfWork.Products.GetAllAsync()).FirstOrDefault(p => p.Id == id);
        if (product is null)
            throw new MarketException(404, "Product not found");

        var mappedProduct = _mapper.Map(dto, product);
        mappedProduct.Update();
        mappedProduct.Id = id;
        var updatedProduct = await _unitOfWork.Products.UpdateAsync(mappedProduct);

        return updatedProduct;
    }

    public async Task<int> DeleteAsync(Func<Product, bool> expression)
    {
        var product = (await _unitOfWork.Products.GetAllAsync()).FirstOrDefault(expression);
        if (product is null)
            throw new MarketException(404, "Product not found");

        var result = await _unitOfWork.Products.DeleteAsync(product.Id);

        return result;
    }
}