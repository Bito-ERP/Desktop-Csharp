using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;
internal class OrganizationApi
{
    public static async Task<BaseResponse<List<OrganizationResponse>>> GetAll() =>
        await Client.Post<List<OrganizationResponse>>("employee/settings/organization/get");
}

