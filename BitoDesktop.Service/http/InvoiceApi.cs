using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Finance;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;
internal class InvoiceApi
{

    public static async Task<BaseResponse<InvoiceResponse>> GetById(RequestBy request) =>
     await Client.Post<InvoiceResponse>("employee/finance/invoice/get-by-id", request);

    public static async Task<BaseResponse<InvoiceResponse>> GetByTrade(RequestBy request) =>
     await Client.Post<InvoiceResponse>("employee/finance/invoice/get-by-trade", request);

    public static async Task<BaseResponse<PagingResponse<InvoiceResponse>>> GetPage(RequestPage request) =>
     await Client.Post<PagingResponse<InvoiceResponse>>("employee/finance/invoice/get-paging", request);

}
