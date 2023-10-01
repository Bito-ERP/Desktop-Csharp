using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Finance;
using BitoDesktop.Service.DTOs.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;

internal class TaxApi
{
    public static async Task<BaseResponse<DiscountResponse>> Create(RequestTaxCU request) =>
    await Client.Post<DiscountResponse>("employee/finance/tax/create", request);

    public static async Task<BaseResponse<DiscountResponse>> Update(RequestTaxCU request) =>
       await Client.Post<DiscountResponse>("employee/finance/tax/update", request);

    public static async Task<BaseResponse<List<DiscountResponse>>> GetAll() =>
      await Client.Post<List<DiscountResponse>>("employee/finance/tax/get-all");

    public static async Task Delete(RequestBy request) =>
      await Client.Post("employee/finance/tax/delete", request);

    public static async Task<BaseResponse<List<String>>> GetDeleteds(RequestBy request) =>
      await Client.Post<List<String>>("employee/finance/tax/get-deleted", request);
}
