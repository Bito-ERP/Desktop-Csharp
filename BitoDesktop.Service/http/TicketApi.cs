using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Pos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Http;
public class TicketApi
{
    public static async Task<BaseResponse<List<TableResponse>>> GetTables() =>
        await Client.Post<List<TableResponse>>("employee/settings/booking-table/get-all");

}
