using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Pos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Http;
public class PosApi
{

    public static async Task<BaseResponse<IEnumerable<PageResponse>>> GetPages() =>
     await Client.Post<IEnumerable<PageResponse>>("employee/pos/page/get-all");

    public static async Task<BaseResponse<IEnumerable<PageItemResponse>>> GetPageItems(RequestBy request) =>
        await Client.Post<IEnumerable<PageItemResponse>>("employee/pos/page/item/get-all", request);

    public static async Task<BaseResponse<PageItemResponse>> CreateItem(RequestPageItemCreate request) =>
     await Client.Post<PageItemResponse>("employee/pos/page/item/create", request);

    public static async Task UpdateItem(RequestPageItemUpdate request) =>
      await Client.Post("employee/pos/page/item/update", request);

    public static async Task DeleteItem(RequestBy request) =>
      await Client.Post("employee/pos/page/item/delete", request);

    public static async Task<BaseResponse<PageItemResponse>> CreatePage(RequestBy request) =>
       await Client.Post<PageItemResponse>("employee/pos/page/create", request);

    public static async Task UpdateItem(RequestPageUpdate request) =>
      await Client.Post("employee/pos/page/update", request);

    public static async Task DeletePage(RequestBy request) =>
      await Client.Post("employee/pos/page/delete", request);

}
