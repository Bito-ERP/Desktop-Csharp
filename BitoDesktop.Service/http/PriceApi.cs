using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;

internal class PriceApi
{
    public static async Task<BaseResponse<PagingResponse<PriceResponse>>> GetPage(RequestPage request) =>
      await Client.Post<PagingResponse<PriceResponse>>("employee/settings/price/get-paging", request);

    public static async Task<BaseResponse<IEnumerable<PriceResponse>>> GetAll() =>
       await Client.Post<IEnumerable<PriceResponse>>("employee/settings/price/get-all");

    public static async Task<BaseResponse<PriceResponse>> Create(RequestPriceCU request) =>
      await Client.Post<PriceResponse>("employee/settings/price/create", request);

    public static async Task<BaseResponse<PriceResponse>> Refund(RequestPriceCU request) =>
      await Client.Post<PriceResponse>("employee/settings/price/update", request);

    public static async Task Delete(RequestBy request) =>
       await Client.Post("employee/settings/price/delete", request);

    public static async Task<BaseResponse<IEnumerable<string>>> GetDeleteds(RequestBy request) =>
   await Client.Post<IEnumerable<string>>("employee/settings/price/get-deleted", request);
}
