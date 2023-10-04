using BitoDesktop.Service.DTOs.Auth;
using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Hr;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;

public class EmployeeApi
{

    public static async Task<BaseResponse<PagingResponse<EmployeeResponse>>> GetPage(RequestPage request) =>
       await Client.Post<PagingResponse<EmployeeResponse>>("employee/v2/hr/employee/get-paging", request);

    public static async Task<BaseResponse<EmployeeResponse>> Create(RequestEmployeeCU request) =>
     await Client.Post<EmployeeResponse>("employee/hr/employee/create", request);

    public static async Task<BaseResponse<EmployeeResponse>> Update(RequestEmployeeCU request) =>
     await Client.Post<EmployeeResponse>("employee/hr/employee/update", request);

    public static async Task Delete(RequestBy request) =>
     await Client.Post("employee/hr/employee/delete", request);

    public static async Task<BaseResponse<List<string>>> GetDeleteds(RequestBy request) =>
     await Client.Post<List<string>>("employee/hr/employee/get-deleted", request);

    public static async Task<BaseResponse<EmployeeResponse>> GetById(RequestBy request) =>
      await Client.Post<EmployeeResponse>("employee/hr/user/get-by-id", request);

    public static async Task<BaseResponse<EmployeeResponse>> GetByPincode(RequestLogin request) =>
      await Client.Post<EmployeeResponse>("employee/hr/employee/get-by-pincode", request);

}

