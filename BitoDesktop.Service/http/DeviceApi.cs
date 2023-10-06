using BitoDesktop.Service.DTOs.Auth;
using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Hr;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Http;

public class DeviceApi
{
    public static async Task<BaseResponse<PagingResponse<DeviceResponse>>> GetPage(RequestPage request) =>
        await Client.Post<PagingResponse<DeviceResponse>>("employee/settings/device/get-paging", request);

    public static async Task<BaseResponse<EmployeeResponse>> BroneDevice(RequestUseDevice request) =>
      await Client.Post<EmployeeResponse>("employee/settings/device/brone", request);

    public static async Task<BaseResponse<DeviceResponse>> GetById(RequestBy request) =>
      await Client.Post<DeviceResponse>("employee/settings/device/get-by-id", request);

}

