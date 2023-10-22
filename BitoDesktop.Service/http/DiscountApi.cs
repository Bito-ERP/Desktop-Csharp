using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Sale;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Http;

public class DiscountApi
{

    public static async Task<BaseResponse<DiscountResponse>> Create(RequestDiscountCU request) =>
        await Client.Post<DiscountResponse>("employee/sale/discount/create", request);

    public static async Task<BaseResponse<DiscountResponse>> Update(RequestDiscountCU request) =>
       await Client.Post<DiscountResponse>("employee/sale/discount/update", request);

    public static async Task<BaseResponse<PagingResponse<DiscountResponse>>> GetPage(RequestPage request) =>
      await Client.Post<PagingResponse<DiscountResponse>>("employee/sale/discount/get-paging", request);

    public static async Task<BaseResponse<List<DiscountResponse>>> GetAll() =>
      await Client.Post<List<DiscountResponse>>("employee/sale/discount/get-all");

    public static async Task Delete(RequestBy request) =>
      await Client.Post("employee/sale/discount/delete", request);

    public static async Task<BaseResponse<List<string>>> GetDeleteds(RequestBy request) =>
      await Client.Post<List<string>>("employee/sale/discount/get-deleted", request);

}

