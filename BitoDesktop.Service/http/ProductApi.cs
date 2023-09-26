using BitoDesktop.Service.DTOs;
using BitoDesktop.Service.DTOs.common;
using BitoDesktop.Service.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;

internal class ProductApi
{

    public async Task<BaseResponse<PagingResponse<ProductResponse>>> GetPage(RequestPage request) =>
       await Client.Post<PagingResponse<ProductResponse>>("employee/good/get-paging", request);

    public async Task<BaseResponse<PagingResponse<ProductResponse>>> GetPageForChoose(RequestPage request) =>
     await Client.Post<PagingResponse<ProductResponse>>("employee/good/stock/get-choose", request);

    public async Task<BaseResponse<PagingResponse<ProductResponse>>> GetWarehousePage(RequestPage request) =>
     await Client.Post<PagingResponse<ProductResponse>>("employee/product/warehouse/get-paging", request);

    public async Task<BaseResponse<PagingResponse<ProductResponse>>> GetPricePage(RequestPage request) =>
     await Client.Post<PagingResponse<ProductResponse>>("employee/product/price/get-paging", request);

    public async Task<BaseResponse<ProductResponse>> Create(RequestProductCU request) =>
     await Client.Post<ProductResponse>("employee/product/create", request);

    public async Task<BaseResponse<ProductResponse>> Update(RequestProductCU request) =>
     await Client.Post<ProductResponse>("employee/product/update", request);

    public async Task Delete(RequestBy request) =>
     await Client.Post("employee/product/delete", request);

    public async Task<BaseResponse<List<string>>> GetDeletedProducts(RequestBy request) =>
     await Client.Post<List<string>>("employee/product/get-deleted", request);

    public async Task<BaseResponse<List<string>>> GetDeletedWarehouses(RequestBy request) =>
      await Client.Post<List<string>>("employee/product/warehouse/get-deleted", request);

    public async Task<BaseResponse<List<string>>> GetDeletedPrices(RequestBy request) =>
      await Client.Post<List<string>>("employee/product/price/get-deleted", request);

    public async Task<BaseResponse<ProductResponse>> GetById(RequestBy request) =>
      await Client.Post<ProductResponse>("employee/product/get-by-id", request);

    public async Task<BaseResponse<ProductResponse>> GetByBarcode(RequestBy request) =>
      await Client.Post<ProductResponse>("employee/product/get-by-barcode", request);

    public async Task<BaseResponse<ProductResponse>> GetBySku(RequestBy request) =>
      await Client.Post<ProductResponse>("employee/product/get-by-sku", request);
    public async Task<BaseResponse<ProductResponse>> GetByMark(RequestBy request) =>
      await Client.Post<ProductResponse>("employee/good/stock/get-by-mark", request);

}

