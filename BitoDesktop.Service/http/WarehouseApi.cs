using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.WarehouseP;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Http;
public class WarehouseApi
{
    public static async Task<BaseResponse<PagingResponse<WarehouseResponse>>> GetPage(RequestPage request) =>
     await Client.Post<PagingResponse<WarehouseResponse>>("employee/warehouse/warehouse/get-paging", request);

    public static async Task<BaseResponse<IEnumerable<string>>> GetDeleteds(RequestBy request) =>
      await Client.Post<IEnumerable<string>>("employee/warehouse/warehouse/get-deleted", request);
}
