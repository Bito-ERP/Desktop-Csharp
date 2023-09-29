using AutoMapper;
using BitoDesktop.Data.IRepositories;
using BitoDesktop.Data.Repositories.Finance;
using BitoDesktop.Data.Repositories.Settings;
using BitoDesktop.Data.Repositories.Warehouse;
using BitoDesktop.Domain.Configurations;
using BitoDesktop.Domain.Entities.Products;
using BitoDesktop.Service.DTOs;
using BitoDesktop.Service.DTOs.common;
using BitoDesktop.Service.DTOs.Warehouse;
using BitoDesktop.Service.Exceptions;
using BitoDesktop.Service.Extensions;
using BitoDesktop.Service.Helpers;
using BitoDesktop.Service.http;
using BitoDesktop.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services;

public partial class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private readonly ProductRepository repository = new();
    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Product>> GetAllAsync(PaginationParams @params)
    {
        var currencyResponse = (await CurrencyApi.GetAll()).Data.PageData;
        var currencyRepo = new CurrencyRepository();
        await currencyRepo.ReplaceAll(currencyResponse.Select(it => it.Get()));
        await currencyRepo.GetAll(null);

        var measurementResponse = (await UnitMeasurementApi.GetAll()).Data;
        var measurementRepo = new UnitMeasurementRepository();
        await measurementRepo.ReplaceAll(measurementResponse.Select(it => it.Get()));
        await measurementRepo.GetAll();

        var response = (await ProductApi.GetPage(new RequestPage { Limit = 100 })).Data.PageData;
        var organizations = new List<ProductOrganization>();
        var warehouses = new List<ProductWarehouse>();
        var prices = new List<ProductPrice>();

        var products = response.Select<ProductResponse, ProductTable>(product =>
        {
            product.Organizations.ForEach(it => organizations.Add(it.Get(product.Id)));
            product.Warehouses.ForEach(it => warehouses.Add(it.Get()));
            product.Prices.ForEach(it => prices.Add(it.Get()));
            return product.Get();
        }).ToList();

        repository.Insert(
            products,
            organizations,
            warehouses,
            prices
        );

        return await repository.GetProducts(0, 100, organizations[1].OrganizationId, null, null, null, null, null, null, null, null, null, true, false, false, false);
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