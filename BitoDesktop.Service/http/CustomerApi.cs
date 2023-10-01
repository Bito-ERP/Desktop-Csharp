using BitoDesktop.Service.DTOs.Auth;
using BitoDesktop.Service.DTOs.common;
using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.CustomerP;
using BitoDesktop.Service.DTOs.Hr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;

internal class CustomerApi
{
    public static async Task<BaseResponse<PagingResponse<CustomerResponse>>> GetPage(RequestPage request) =>
     await Client.Post<PagingResponse<CustomerResponse>>("employee/sale/customer/get-paging", request);

    public static async Task<BaseResponse<PagingResponse<CustomerResponse.Cashback>>> GetcashbackPage(RequestPage request) =>
      await Client.Post<PagingResponse<CustomerResponse.Cashback>>("employee/sale/customer/cashback/get-paging", request);


    public static async Task<BaseResponse<CustomerResponse>> Create(RequestEmployeeCU request) =>
     await Client.Post<CustomerResponse>("employee/sale/customer/create", request);

    public static async Task<BaseResponse<CustomerResponse>> Update(RequestEmployeeCU request) =>
     await Client.Post<CustomerResponse>("employee/sale/customer/update", request);

    public static async Task Delete(RequestBy request) =>
     await Client.Post("employee/sale/customer/delete", request);

    public static async Task<BaseResponse<List<string>>> GetDeleteds(RequestBy request) =>
     await Client.Post<List<string>>("employee/sale/customer/get-deleted", request);


    public static async Task<BaseResponse<CustomerResponse>> GetById(RequestBy request) =>
      await Client.Post<CustomerResponse>("employee/hr/user/get-by-id", request);

    public static async Task<BaseResponse<CustomerResponseByInn>> GetByInn(RequestBy request) =>
   await Client.Post<CustomerResponseByInn>("employee/hr/user/get-by-inn", request);


    public static async Task<BaseResponse<double>> GetTotalDebt() =>
      await Client.Post<double>("employee/sale/customer/get-debt");
}

