using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Pos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.http;
internal class TicketApi
{
    public static async Task<BaseResponse<List<TableResponse>>> GetTables() =>
        await Client.Post<List<TableResponse>>("employee/settings/booking-table/get-all");

}
