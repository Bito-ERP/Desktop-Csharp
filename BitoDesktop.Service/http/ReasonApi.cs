using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Settings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;

internal class ReasonApi
{

    public static async Task<BaseResponse<ReasonResponse>> Create(RequestReasonCU request) =>
        await Client.Post<ReasonResponse>("employee/settings/reason/create", request);

    public static async Task<BaseResponse<ReasonResponse>> Update(RequestReasonCU request) =>
       await Client.Post<ReasonResponse>("employee/settings/reason/update", request);

    public static async Task<BaseResponse<PagingResponse<ReasonResponse>>> GetPage(RequestPage request) =>
      await Client.Post<PagingResponse<ReasonResponse>>("employee/settings/reason/get-paging", request);

    public static async Task Delete(RequestBy request) =>
      await Client.Post("employee/settings/reason/delete", request);

    public static async Task<BaseResponse<List<String>>> GetDeleteds(RequestBy request) =>
      await Client.Post<List<String>>("employee/settings/reason/get-deleted", request);

}

