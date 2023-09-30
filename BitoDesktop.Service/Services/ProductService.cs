using AutoMapper;
using BitoDesktop.Data.IRepositories;
using BitoDesktop.Data.Repositories.Finance;
using BitoDesktop.Data.Repositories.Sale;
using BitoDesktop.Data.Repositories.Settings;
using BitoDesktop.Data.Repositories.Warehouse;
using BitoDesktop.Domain.Configurations;
using BitoDesktop.Domain.Entities.Products;
using BitoDesktop.Domain.Entities.Sale;
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

        var paymentMethodResponse = (await PaymentMethodApi.GetAll()).Data.PageData;
        var paymentMethodRepo = new PaymentMethodRepository();
        await paymentMethodRepo.ReplaceAll(paymentMethodResponse.Select(it => it.Get()));
        await paymentMethodRepo.GetAll();

        var receiptdResponse = (await ReceiptApi.GetPage(new RequestPage { Limit = 100 })).Data.PageData;
        var receiptdRepo = new ReceiptRepository();

        var payments = new List<ReceiptPayment>();
        var installments = new List<ReceiptInstallment>();
        var cashbacks = new List<ReceiptCashback>();
        var discounts = new List<ReceiptDiscount>();
        var changes = new List<ReceiptChange>();

        var receipts = receiptdResponse.Select(receipt =>
        {
            receipt.Payments.ForEach(it => payments.Add(it.Get(receipt.Uuid)));
            receipt.InstallmentPlans.ForEach(it => installments.Add(it.Get(receipt.Uuid)));
            receipt.AppliedCashbacks.ForEach(it => cashbacks.Add(it.Get(receipt.Uuid)));
            receipt.Discounts.ForEach(it => discounts.Add(it.Get(receipt.Uuid, receipt.Currency.Id)));
            receipt.Changes.ForEach(it => changes.Add(it.Get(receipt.Uuid)));

            return receipt.Get("63d23495f1cf6851fcaf832b");
        }).ToList();

       await receiptdRepo.Insert(
           receipts,
           payments,
           installments,
           cashbacks,
           discounts,
           changes
           );
        var receipt_ = await receiptdRepo.GetReceipts(0, 100, "63d23495f1cf6851fcaf832b", null, null, null, null, null, null, null, null, null, null, false);

        var organizationResponse = (await OrganizationApi.GetAll()).Data;
        var organizationRepo = new OrganizationRepository();
        await organizationRepo.ReplaceAll(organizationResponse.Select(it => it.Get()));
        await organizationRepo.GetAll();

        var response = (await ProductApi.GetPage(new RequestPage { Limit = 100 })).Data.PageData;
        var organizations = new List<ProductOrganization>();
        var warehouses = new List<ProductWarehouse>();
        var prices = new List<ProductPrice>();

        var products = response.Select(product =>
        {
            product.Organizations.ForEach(it => organizations.Add(it.Get(product.Id)));
            product.Warehouses.ForEach(it => warehouses.Add(it.Get()));
            product.Prices.ForEach(it => prices.Add(it.Get()));
            return product.Get();
        }).ToList();

        await repository.Insert(
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