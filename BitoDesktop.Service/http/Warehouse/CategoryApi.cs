using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.WarehouseP;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BitoDesktop.Service.DTOs.Pos.PageItemResponse;

namespace BitoDesktop.Service.http.Warehouse;

internal class CategoryApi
{
    public static async Task<BaseResponse<PagingResponse<DTOs.WarehouseP.CategoryResponse>>> GetPage(RequestPage request) =>
     await Client.Post<PagingResponse<DTOs.WarehouseP.CategoryResponse>>("employee/product/category/get-paging", request);

    public static async Task<BaseResponse<PagingResponse<DTOs.WarehouseP.CategoryResponse>>> GetParentPage(RequestPage request) =>
      await Client.Post<PagingResponse<DTOs.WarehouseP.CategoryResponse>>("employee/product/category/choose-parent", request);


    public static async Task<BaseResponse<DTOs.WarehouseP.CategoryResponse>> Create(RequestCategoryCU request) =>
     await Client.Post<DTOs.WarehouseP.CategoryResponse>("employee/product/category/create", request);

    public static async Task<BaseResponse<DTOs.WarehouseP.CategoryResponse>> Update(RequestCategoryCU request) =>
     await Client.Post<DTOs.WarehouseP.CategoryResponse>("employee/product/category/update", request);

    public static async Task Delete(RequestBy request) =>
     await Client.Post("employee/product/category/delete", request);

    public static async Task<BaseResponse<List<string>>> GetDeleteds(RequestBy request) =>
     await Client.Post<List<string>>("employee/product/category/get-deleted", request);

}

