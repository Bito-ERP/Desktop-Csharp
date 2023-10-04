using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Sale;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;
public class ReceiptApi
{

    public static async Task<BaseResponse<PagingResponse<ReceiptResponse>>> GetPage(RequestPage request) =>
        await Client.Post<PagingResponse<ReceiptResponse>>("employee/pos/receipt/get-paging", request);

    public static async Task<BaseResponse<IEnumerable<ReceiptResponse>>> GetItems(RequestBy request) =>
       await Client.Post<IEnumerable<ReceiptResponse>>("employee/pos/receipt/get-items", request);

    public static async Task<BaseResponse<ReceiptResponse>> Create(RequestReceiptCreate request) =>
      await Client.Post<ReceiptResponse>("employee/pos/receipt/create", request);

    public static async Task<BaseResponse<ReceiptResponse>> Refund(RequestReceiptCreate request) =>
      await Client.Post<ReceiptResponse>("employee/pos/receipt/refund", request);

    public static async Task<BaseResponse<ReceiptResponse>> SetState(RequestSetState request) =>
      await Client.Post<ReceiptResponse>("employee/pos/receipt/set-state", request);

}

