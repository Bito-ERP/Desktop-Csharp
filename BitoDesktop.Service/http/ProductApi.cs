using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.WarehouseP;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Http;

public class ProductApi
{

    public static async Task<BaseResponse<PagingResponse<ProductResponse>>> GetPage(RequestPage request) =>
       await Client.Post<PagingResponse<ProductResponse>>("employee/good/get-paging", request);

    public static async Task<BaseResponse<PagingResponse<ProductResponse>>> GetPageForChoose(RequestPage request) =>
     await Client.Post<PagingResponse<ProductResponse>>("employee/good/stock/get-choose", request);

    public static async Task<BaseResponse<PagingResponse<ProductResponse>>> GetWarehousePage(RequestPage request) =>
     await Client.Post<PagingResponse<ProductResponse>>("employee/product/warehouse/get-paging", request);

    public static async Task<BaseResponse<PagingResponse<ProductResponse>>> GetPricePage(RequestPage request) =>
     await Client.Post<PagingResponse<ProductResponse>>("employee/product/price/get-paging", request);

    public static async Task<BaseResponse<ProductResponse>> Create(RequestProductCU request) =>
     await Client.Post<ProductResponse>("employee/product/create", request);

    public static async Task<BaseResponse<ProductResponse>> Update(RequestProductCU request) =>
     await Client.Post<ProductResponse>("employee/product/update", request);

    public static async Task Delete(RequestBy request) =>
     await Client.Post("employee/product/delete", request);

    public static async Task<BaseResponse<List<string>>> GetDeletedProducts(RequestBy request) =>
     await Client.Post<List<string>>("employee/product/get-deleted", request);

    public static async Task<BaseResponse<List<string>>> GetDeletedWarehouses(RequestBy request) =>
      await Client.Post<List<string>>("employee/product/warehouse/get-deleted", request);

    public static async Task<BaseResponse<List<string>>> GetDeletedPrices(RequestBy request) =>
      await Client.Post<List<string>>("employee/product/price/get-deleted", request);

    public static async Task<BaseResponse<ProductResponse>> GetById(RequestBy request) =>
      await Client.Post<ProductResponse>("employee/product/get-by-id", request);

    public static async Task<BaseResponse<ProductResponse>> GetByBarcode(RequestBy request) =>
      await Client.Post<ProductResponse>("employee/product/get-by-barcode", request);

    public static async Task<BaseResponse<ProductResponse>> GetBySku(RequestBy request) =>
      await Client.Post<ProductResponse>("employee/product/get-by-sku", request);
    public static async Task<BaseResponse<ProductResponse>> GetByMark(RequestBy request) =>
      await Client.Post<ProductResponse>("employee/good/stock/get-by-mark", request);

}

