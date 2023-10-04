using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Settings;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;

public class PrinterApi
{

    public static async Task<BaseResponse<PrinterResponse>> Create(RequestPrinterCU request) =>
        await Client.Post<PrinterResponse>("employee/settings/printer/create", request);

    public static async Task<BaseResponse<PrinterResponse>> Update(RequestPrinterCU request) =>
       await Client.Post<PrinterResponse>("employee/settings/printer/update", request);

    public static async Task<BaseResponse<PagingResponse<PrinterResponse>>> GetAll() =>
      await Client.Post<PagingResponse<PrinterResponse>>("employee/settings/printer/get-all");

    public static async Task Delete(RequestBy request) =>
      await Client.Post("employee/settings/printer/delete", request);

}

