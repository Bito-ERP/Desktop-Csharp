using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;

internal class AccessApi
{

    public static async Task<BaseResponse<List<AccessResponse>>> GetAccesses(RequestBy request) =>
      await Client.Post<List<AccessResponse>>("employee/hr/access/get", request);

    public static async Task<BaseResponse<AccessResponse.RoleResponse>> GetRole(RequestBy request) =>
    await Client.Post<AccessResponse.RoleResponse>("employee/hr/role/get-by-id", request);

}

